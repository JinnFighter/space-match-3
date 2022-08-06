using Leopotam.Ecs;
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

        void Start() 
        {   
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);

            #if UNITY_EDITOR
                Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
                Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_systems);
            #endif

            _systems
                .Inject(_gameFieldModel)
                .Inject(_gameFieldDescription)
                .Init();
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