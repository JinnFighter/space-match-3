using Assets.Scripts.Logic.Components.Gameplay;
using Assets.Scripts.Logic.Components.Tiles;
using Assets.Scripts.Logic.Descriptions;
using Assets.Scripts.Logic.Models;
using Assets.Scripts.Logic.Systems.GameField;
using Assets.Scripts.Logic.Systems.Gameplay;
using Assets.Scripts.Logic.Systems.Input;
using Assets.Scripts.Logic.Systems.Tiles;
using Leopotam.Ecs;
using Logic.Generators;
using Logic.MatchCheckers;
using Logic.Models;
using Logic.Systems.GameField;
using Logic.Systems.Tiles;
using VContainer;
using Voody.UniLeo;

namespace Startups.LogicContainers
{
    public class EcsLogicContainer : ILogicContainer
    {
        private EcsWorld _world;
        private EcsSystems _systems;
        
        private readonly TileColorsDescription _tileColorsDescription;
        private readonly TileClickInputModel _tileClickInputModel;
        private readonly GameStateModel _gameStateModel;
        private readonly GameFieldModel _gameFieldModel;
        private readonly TileSelectionModel _tileSelectionModel;
        private readonly ScoreModel _scoreModel;
        private readonly TurnCountModel _turnCountModel;
        private readonly IGameFieldGenerator _gameFieldGenerator;
        private readonly IMatchChecker _matchChecker;

        [Inject]
        public EcsLogicContainer(TileColorsDescription tileColorsDescription, TileClickInputModel tileClickInputModel, GameStateModel gameStateModel, GameFieldModel gameFieldModel, TileSelectionModel tileSelectionModel, ScoreModel scoreModel, TurnCountModel turnCountModel, IGameFieldGenerator gameFieldGenerator, IMatchChecker matchChecker)
        {
            _tileColorsDescription = tileColorsDescription;
            _tileClickInputModel = tileClickInputModel;
            _gameStateModel = gameStateModel;
            _gameFieldModel = gameFieldModel;
            _tileSelectionModel = tileSelectionModel;
            _scoreModel = scoreModel;
            _turnCountModel = turnCountModel;
            _gameFieldGenerator = gameFieldGenerator;
            _matchChecker = matchChecker;
        }

        public void Init()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);

            #if UNITY_EDITOR
                        Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
                        Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_systems);
            #endif

            AddExtensions();
            AddInitSystems();
            AddRunSystems();
            AddOneFrameComponents();
            AddInjections();

            _systems.Init();
        }

        public void Destroy()
        {
            if (_systems != null)
            {
                _systems.Destroy();
                _systems = null;
                _world.Destroy();
                _world = null;
            }
        }

        private void AddExtensions()
        {
            _systems
                .ConvertScene();
        }

        private void AddOneFrameComponents()
        {
            _systems
                .OneFrame<TileClicked>()
                .OneFrame<TurnEvent>()
                .OneFrame<MatchEvent>()
                .OneFrame<GameOverEvent>();
        }

        private void AddRunSystems()
        {
            _systems
                .Add(new CheckTileClickSystem())
                .Add(new ClearInputModelsSystem())
                .Add(new SetTileSelectionSystem())
                .Add(new UpdateTurnCountSystem())
                .Add(new CreateMatchRequestOnTurnSystem())
                .Add(new CheckMatchesSystem())
                .Add(new ClearMatchedTileSystem())
                .Add(new AddScoreOnMatchSystem())
                .Add(new ShiftTilesSystem());
        }

        private void AddInjections()
        {
            _systems
                .Inject(_gameStateModel)
                .Inject(_tileClickInputModel)
                .Inject(_gameFieldModel)
                .Inject(_tileSelectionModel)
                .Inject(_scoreModel)
                .Inject(_turnCountModel)
                .Inject(_gameFieldGenerator)
                .Inject(_matchChecker)
                .Inject(_tileColorsDescription);
        }

        private void AddInitSystems()
        {
            _systems
                .Add(new InitGameFieldSystem());
        }

        public void RunSystems()
        {
            _systems?.Run();
        }
    }
}
