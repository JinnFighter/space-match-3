using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Logic.Views
{
    public class GameOverView : MonoBehaviour
    {
        [field: SerializeField] public Button RestartButton { get; private set; }
        
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