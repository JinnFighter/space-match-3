using UnityEngine;

[CreateAssetMenu(fileName = "DescriptionsContent", menuName = "Descriptions/DescriptionsContent")]
public class DescriptionsContent : ScriptableObject
{
    [field: SerializeField] public GameFieldDescription GameFieldDescription { get; private set; }
    [field: SerializeField] public TileStatesDescription TileStatesDescription { get;private set; }
}
