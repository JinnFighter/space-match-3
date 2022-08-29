using UnityEngine;

namespace Assets.Scripts.Logic.Views
{
    public class GameOverView : MonoBehaviour
    {
        private GameObject _gameObject;
        public GameObject GameObject
        {
            get
            {
                if (_gameObject == null)
                {
                    _gameObject = gameObject;
                }
                
                return _gameObject;
            }
        }
    }
}