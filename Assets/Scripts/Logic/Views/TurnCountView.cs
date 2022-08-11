using TMPro;
using UnityEngine;

public class TurnCountView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _turnCountText;

    public void SetTurnCount(int turnCount) => _turnCountText.text = $"Turn Count: { turnCount }";
}
