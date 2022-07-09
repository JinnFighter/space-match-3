using UnityEngine;
using TMPro;

public class TileView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _stateText;

    public void SetState(int state) => _stateText.text = $"{ state }";
}
