using TMPro;
using UnityEngine;

namespace Assets.Scripts.Logic.Views
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;

        public void SetScore(int score) => _scoreText.text = $"Score: { score }";
    }
}