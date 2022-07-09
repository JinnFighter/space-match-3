using Assets.Scripts.Common;
using Assets.Scripts.Logic.Models;
using Assets.Scripts.Logic.Systems;
using Assets.Scripts.View.Content;
using Assets.Scripts.View.Systems;
using Leopotam.Ecs;
using UnityEngine;

namespace SpaceMatch3
{
    sealed class GameplayStartup : MonoBehaviour 
    {
        EcsWorld _world;
        EcsSystems _logicSystems;
        EcsSystems _uiSystems;

        [SerializeField] private GameFieldDescription _gameFieldDescription;
        [SerializeField] private TileStatesDescription _tileStatesDescription;

        [SerializeField] private ViewContainer _viewContainer;
        [SerializeField] private PrefabsContent _prefabsContent;

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
            var gameFieldModel = new GameFieldModel();
            _logicSystems
                //Init systems go here:
                .Add(new InitGameFieldSystem())
                //Run systems go here:

                //Injected classes go here:
                .Inject(gameFieldModel)
                .Inject(_gameFieldDescription)
                .Inject(_tileStatesDescription)
                .Init();

            _uiSystems
                //Init systems go here:
                .Add(new InitTileViewSystem())
                //Run systems go here:
                .Add(new UpdateTileViewStateSystem())
                //Injected classes go here:
                .Inject(gameFieldModel)
                .Inject(_viewContainer)
                .Inject(_prefabsContent)
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