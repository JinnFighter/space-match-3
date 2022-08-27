using Startups.LogicContainers;
using UnityEngine;
using Zenject;

namespace Startups
{
    internal sealed class GameplayStartup : MonoBehaviour 
    {
        [Inject] private EcsLogicContainer _ecsLogicContainer;
        [Inject] private PresenterLogicContainer _presenterLogicContainer;

        void Start() 
        {   
            _ecsLogicContainer.Init();
            _presenterLogicContainer.Init();
        }

        void Update() 
        {
            _ecsLogicContainer.RunSystems();
        }

        void OnDestroy() 
        {
            _presenterLogicContainer.Destroy();
            _ecsLogicContainer.Destroy();
        }
    }
}