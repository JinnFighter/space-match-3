using Leopotam.Ecs;
using UnityEngine;

namespace SpaceMatch3 
{
    sealed class GameplayStartup : MonoBehaviour 
    {
        EcsWorld _world;
        EcsSystems _logicSystems;
        EcsSystems _uiSystems;

        void Start() 
        {
            // void can be switched to IEnumerator for support coroutines.
            
            _world = new EcsWorld();
            _logicSystems = new EcsSystems(_world);
            _uiSystems = new EcsSystems(_world);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_logicSystems);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_uiSystems);
#endif
            _logicSystems
                .Init();

            _uiSystems
                .Init();
        }

        void Update()
        {
            _logicSystems?.Run();
            _uiSystems?.Run();
        }

        void OnDestroy() 
        {
            if (_uiSystems != null)
            {
                _uiSystems.Destroy();
                _uiSystems = null;
            }

            if (_logicSystems != null) 
            {
                _logicSystems.Destroy();
                _logicSystems = null;
            }

            _world.Destroy();
            _world = null;
        }
    }
}