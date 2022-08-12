using UnityEngine;

namespace Assets.Scripts.Logic.Descriptions
{
    [CreateAssetMenu(fileName = "LevelDescription", menuName = "Descriptions/LevelDescription")]
    public class LevelDescription : ScriptableObject
    {
        [field: SerializeField] public int TurnCount { get; private set; } = 20;
    }
}