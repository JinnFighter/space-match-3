using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Logic.Views
{
    public class TileView : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Image _ballImage;

        private Vector3 _originalBallScale;

        void Awake()
        {
            _originalBallScale = BallTransform.localScale;
        }

        private GameObject _ballGameObject;
        public GameObject BallGameObject 
        { 
            get
            {
                if(_ballGameObject == null)
                {
                    _ballGameObject = _ballImage.gameObject;
                }

                return _ballGameObject;
            } 
        }

        private Transform _ballTransform;
        public Transform BallTransform
        {
            get
            {
                if (_ballTransform == null)
                {
                    _ballTransform = _ballImage.transform;
                }

                return _ballTransform;
            }
        }

        public bool IsClicked;

        public void SetColor(Color color) => _ballImage.color = color;

        public void EnableBall() => BallGameObject.SetActive(true);
        public void DisableBall() => BallGameObject.SetActive(false);

        public void Select() => BallTransform.localScale = _originalBallScale * 1.05f;

        public void Deselect() => BallTransform.localScale = _originalBallScale;

        public void OnPointerClick(PointerEventData eventData) => IsClicked = true;

        public void ResetClicked() => IsClicked = false;
    }
}