using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Logic.Views
{
    public class TileView : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private TextMeshProUGUI _stateText;
        [SerializeField] private Image _stateImage;
        [SerializeField] private Image _ballImage;

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

        public bool IsClicked;

        public void SetState(int state) => _stateText.text = state >= 0 ? $"{state}" : "-";
        public void SetColor(Color color) => _ballImage.color = color;

        public void EnableBall() => BallGameObject.SetActive(true);
        public void DisableBall() => BallGameObject.SetActive(false);

        public void Select() => _stateImage.color = new Color(_stateImage.color.r, _stateImage.color.g, _stateImage.color.b, 1f);

        public void Deselect() => _stateImage.color = new Color(_stateImage.color.r, _stateImage.color.g, _stateImage.color.b, 0.5f);

        public void OnPointerClick(PointerEventData eventData) => IsClicked = true;

        public void ResetClicked() => IsClicked = false;
    }
}