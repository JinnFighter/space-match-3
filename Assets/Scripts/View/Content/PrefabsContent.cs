using Assets.Scripts.View.Views;
using UnityEngine;

namespace Assets.Scripts.View.Content
{
    [CreateAssetMenu(fileName = "PrefabsContent", menuName = "Content/PrefabsContent")]
    public class PrefabsContent : ScriptableObject
    {
        [field: SerializeField] public TileView TileView { get; private set; }
    }
}