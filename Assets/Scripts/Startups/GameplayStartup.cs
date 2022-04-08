using Leopotam.Ecs;
using UnityEngine;

namespace SpaceMatch3 
{
    sealed class GameplayStartup : MonoBehaviour 
    {
        private EcsWorld _world;
        private EcsSystems _logicSystems;
        private EcsSystems _uiSystems;

        void Start () {
            // void can be switched to IEnumerator for support coroutines.
            
            _world = new EcsWorld ();
            _logicSystems = new EcsSystems (_world);
            _uiSystems = new EcsSystems(_world);

#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_logicSystems);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_uiSystems);
#endif
            _logicSystems
                // Init systems go here:
                // Run systems go here:
                // Destroy systems go here:
                
                // register one-frame components (order is important), for example:
                // .OneFrame<TestComponent1> ()
                // .OneFrame<TestComponent2> ()
                
                // inject service instances here (order doesn't important), for example:
                // .Inject (new CameraService ())
                // .Inject (new NavMeshSupport ())
                .Init ();

            _uiSystems
                // Init systems go here:
                // Run systems go here:
                // Destroy systems go here:

                // register one-frame components (order is important), for example:
                // .OneFrame<TestComponent1> ()
                // .OneFrame<TestComponent2> ()

                // inject service instances here (order doesn't important), for example:
                // .Inject (new CameraService ())
                // .Inject (new NavMeshSupport ())
                .Init();
        }

        void Update() 
        {
            _logicSystems?.Run ();
            _uiSystems?.Run();
        }

        void OnDestroy() 
        {
            if (_logicSystems != null) 
            {
                _logicSystems.Destroy ();
                _logicSystems = null;
            }

            if (_uiSystems != null)
            {
                _uiSystems.Destroy();
                _uiSystems = null;
            }

            if (_world != null)
            {
                _world.Destroy();
                _world = null;
            }
        }
    }
}