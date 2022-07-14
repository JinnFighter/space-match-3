using TMPro;
using UnityEngine;

public class TileView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _stateText;

    public void SetState(int state) => _stateText.text = state >= 0 ? $"{ state }" : "-";
}
