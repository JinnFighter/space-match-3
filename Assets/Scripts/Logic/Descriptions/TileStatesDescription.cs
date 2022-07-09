using UnityEngine;

[CreateAssetMenu(fileName = "TileStatesDescription", menuName = "Descriptions/TileStatesDescriptions")]
public class TileStatesDescription : ScriptableObject
{
    [field: SerializeField] public int EmptyFieldState { get; private set; } = -1;
    [field: SerializeField] public int MaxState { get; private set; } = 5;
}
