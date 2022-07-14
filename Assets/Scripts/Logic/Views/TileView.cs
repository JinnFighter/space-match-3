using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TileView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _stateText;
    [SerializeField] private Image _stateImage;

    public void SetState(int state) => _stateText.text = state >= 0 ? $"{ state }" : "-";

    public void Select() => _stateImage.color = new Color(_stateImage.color.r, _stateImage.color.g, _stateImage.color.b, 255);

    public void Deselect() => _stateImage.color = new Color(_stateImage.color.r, _stateImage.color.g, _stateImage.color.b, 128);
}
