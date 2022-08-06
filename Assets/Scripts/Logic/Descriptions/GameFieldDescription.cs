using UnityEngine;

[CreateAssetMenu(fileName = "GameFieldDescription", menuName = "Descriptions/GameFieldDescription")]
public class GameFieldDescription : ScriptableObject
{
    [field: SerializeField] public int Width { get; private set; } = 5;
    [field: SerializeField] public int Height { get; private set; } = 5;
    [field: SerializeField] public int EmptyFieldState { get; private set; } = -1;
    [field: SerializeField] public int MaxState { get; private set; } = 5;
}
