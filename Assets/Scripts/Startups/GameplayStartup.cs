using Assets.Scripts.Common;
using Assets.Scripts.Init;
using Assets.Scripts.Logic.Content;
using UnityEngine;

namespace SpaceMatch3
{
    sealed class GameplayStartup : MonoBehaviour 
    {
        [SerializeField] private ViewContainer _viewContainer;
        [SerializeField] private PrefabsContent _prefabsContent;
        [SerializeField] private DescriptionsContent _descriptionsContent;

        private IGame _game;

        void Start() 
        {
            _game = new Game
            {
                ControllerContainer = new ControllerContainer(),
                PrefabsContent = _prefabsContent,
                DescriptionContent = _descriptionsContent,
            };

            foreach(var init in new InitContainer())
            {
                init.Init(_game);
            }

            _game.ControllerContainer.Enable();
        }

        void OnDestroy() 
        {
            _game.ControllerContainer.Disable();
            _game.ControllerContainer.Clear();
        }
    }
}