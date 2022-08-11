using Assets.Scripts.Common;
using Assets.Scripts.Logic.Components.Gameplay;
using Assets.Scripts.Logic.Components.Tiles;
using Assets.Scripts.Logic.Generators;
using Assets.Scripts.Logic.Models;
using Assets.Scripts.Logic.Systems.GameField;
using Assets.Scripts.Logic.Systems.Gameplay;
using Assets.Scripts.Logic.Systems.Tiles;
using Assets.Scripts.Logic.Systems.Ui;
using Assets.Scripts.Logic.Views;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;
using Zenject;

namespace SpaceMatch3
{
    sealed class GameplayStartup : MonoBehaviour 
    {
        private EcsWorld _world;
        private EcsSystems _systems;

        [Inject]
        private GameFieldModel _gameFieldModel;
        [Inject]
        private TileSelectionModel _tileSelectionModel;
        [Inject]
        private ScoreModel _scoreModel;
        [Inject]
        private IGameFieldGenerator _gameFieldGenerator;
        [Inject]
        private GameFieldView _gameFieldView;
        [Inject]
        private TileView _tileView;
        [Inject]
        private ViewContainer _viewContainer;

        void Start() 
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
                .OneFrame<MatchEvent>();
        }

        private void AddRunSystems()
        {
            _systems
                .Add(new CheckTileClickedSystem())
                .Add(new SetTileSelectionSystem())
                .Add(new CreateMatchRequestOnTurnSystem())
                .Add(new CheckMatchesSystem())
                .Add(new ClearMatchedTileSystem())
                .Add(new AddScoreOnMatchSystem())
                .Add(new ShiftTilesSystem())
                .Add(new UpdateTileStatesSystem())
                .Add(new UpdateTileSelectionSystem())
                .Add(new UpdateScoreViewSystem());
        }

        private void AddInjections()
        {
            _systems
                .Inject(_gameFieldModel)
                .Inject(_tileSelectionModel)
                .Inject(_scoreModel)
                .Inject(_gameFieldGenerator)
                .Inject(_gameFieldView)
                .Inject(_tileView)
                .Inject(_viewContainer);
        }

        private void AddInitSystems()
        {
            _systems
                .Add(new InitGameFieldSystem())
                .Add(new InitGameFieldViewSystem());
        }

        void Update() 
        {
            _systems?.Run();
        }

        void OnDestroy() 
        {
            if (_systems != null) 
            {
                _systems.Destroy();
                _systems = null;
                _world.Destroy();
                _world = null;
            }
        }
    }
}