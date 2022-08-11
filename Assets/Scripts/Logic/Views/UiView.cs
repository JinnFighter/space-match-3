using UnityEngine;

namespace Assets.Scripts.Logic.Views
{
    public class UiView : MonoBehaviour
    {
        [field: SerializeField] public ScoreView ScoreView { get; private set; }
    }
}