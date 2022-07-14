using Assets.Scripts.Common;
using Assets.Scripts.Init;
using UnityEngine;

namespace SpaceMatch3
{
    sealed class GameplayStartup : MonoBehaviour 
    {
        [SerializeField] private GameFieldDescription _gameFieldDescription;
        [SerializeField] private TileStatesDescription _tileStatesDescription;

        [SerializeField] private ViewContainer _viewContainer;

        private IGame _game;

        void Start() 
        {
            _game = new Game
            {
                ControllerContainer = new ControllerContainer(),
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