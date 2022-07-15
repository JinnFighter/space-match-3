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

        public void SetState(int state) => _stateText.text = state >= 0 ? $"{state}" : "-";

        public void Select() => _stateImage.color = new Color(_stateImage.color.r, _stateImage.color.g, _stateImage.color.b, 1f);

        public void Deselect() => _stateImage.color = new Color(_stateImage.color.r, _stateImage.color.g, _stateImage.color.b, 0.5f);

        public void OnPointerClick(PointerEventData eventData)
        {
            ClickEvent?.Invoke();
        }

        public delegate void VoidDelegate();
        public event VoidDelegate ClickEvent;
    }
}