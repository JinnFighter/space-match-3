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

        public bool IsClicked { get; private set; }

        public void SetState(int state) => _stateText.text = state >= 0 ? $"{state}" : "-";

        public void Select() => _stateImage.color = new Color(_stateImage.color.r, _stateImage.color.g, _stateImage.color.b, 255);

        public void Deselect() => _stateImage.color = new Color(_stateImage.color.r, _stateImage.color.g, _stateImage.color.b, 128);

        public void OnPointerClick(PointerEventData eventData)
        {
            IsClicked = true;
        }

        public void ResetClicked() => IsClicked = false;
    }
}