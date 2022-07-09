using UnityEngine;

[CreateAssetMenu(fileName = "PrefabsContent", menuName = "Content/PrefabsContent")]
public class PrefabsContent : ScriptableObject
{
    [field: SerializeField] public TileView TileView { get; private set; }
}
