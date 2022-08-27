using Assets.Scripts.Common;
using Assets.Scripts.Logic.Components.Gameplay;
using Assets.Scripts.Logic.Components.Tiles;
using Assets.Scripts.Logic.Descriptions;
using Assets.Scripts.Logic.Models;
using Assets.Scripts.Logic.Systems.GameField;
using Assets.Scripts.Logic.Systems.Gameplay;
using Assets.Scripts.Logic.Systems.Input;
using Assets.Scripts.Logic.Systems.Tiles;
using Assets.Scripts.Logic.Systems.Ui;
using Assets.Scripts.Logic.Views;
using Leopotam.Ecs;
using Logic.Generators;
using Logic.MatchCheckers;
using Logic.Models;
using Logic.Systems.GameField;
using Logic.Systems.Tiles;
using Voody.UniLeo;
using Zenject;

namespace Startups.LogicContainers
{
    public class EcsLogicContainer : ILogicContainer
    {
        private EcsWorld _world;
        private EcsSystems _systems;

        [Inject] private TileColorsDescription _tileColorsDescription;
        [Inject] private TileClickInputModel _tileClickInputModel;
        [Inject] private GameFieldModel _gameFieldModel;
        [Inject] private TileSelectionModel _tileSelectionModel;
        [Inject] private ScoreModel _scoreModel;
        [Inject] private TurnCountModel _turnCountModel;
        [Inject] private IGameFieldGenerator _gameFieldGenerator;
        [Inject] private IMatchChecker _matchChecker;
        [Inject] private ViewContainer _viewContainer;

        [Inject] private GameOverView _gameOverView;
        
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
                .Add(new ShiftTilesSystem())
                .Add(new EnableGameOverViewSystem());
        }

        private void AddInjections()
        {
            _systems
                .Inject(_tileClickInputModel)
                .Inject(_gameFieldModel)
                .Inject(_tileSelectionModel)
                .Inject(_scoreModel)
                .Inject(_turnCountModel)
                .Inject(_gameFieldGenerator)
                .Inject(_matchChecker)
                .Inject(_tileColorsDescription)
                .Inject(_gameOverView)
                .Inject(_viewContainer);
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
