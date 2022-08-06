using Assets.Scripts.Common;
using Assets.Scripts.Logic.Systems.GameField;
using Assets.Scripts.Logic.Views;
using Leopotam.Ecs;
using System;
using UnityEngine;
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
        private GameFieldDescription _gameFieldDescription;
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

            AddInitSystems();
            AddRunSystems();
            AddOneFrameComponents();
            AddInjections();

            _systems.Init();
        }

        private void AddOneFrameComponents()
        {
        }

        private void AddRunSystems()
        {
        }

        private void AddInjections()
        {
            _systems
                .Inject(_gameFieldModel)
                .Inject(_gameFieldDescription)
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