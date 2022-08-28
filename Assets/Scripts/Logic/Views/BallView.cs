using UnityEngine;
using UnityEngine.UI;

namespace Logic.Views
{
    public class BallView : MonoBehaviour
    {
        [SerializeField] private Image _ballImage;

        private Vector3 _originalBallScale;
        
        private Transform _transform;
        public Transform Transform
        {
            get
            {
                if (_transform == null)
                {
                    _transform = _ballImage.transform;
                }

                return _transform;
            }
        }
        
        private GameObject _gameObject;
        public GameObject GameObject 
        { 
            get
            {
                if(_gameObject == null)
                {
                    _gameObject = _ballImage.gameObject;
                }

                return _gameObject;
            } 
        }

        void Awake()
        {
            _originalBallScale = Transform.localScale;
        }


        public void SetColor(Color color) => _ballImage.color = color;

        public void Select() => Transform.localScale = _originalBallScale * 1.05f;

        public void Deselect() => Transform.localScale = _originalBallScale;
    }
}
