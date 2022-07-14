using Assets.Scripts.Logic.Views;
using UnityEngine;

namespace Assets.Scripts.Logic.Content
{
    [CreateAssetMenu(fileName = "PrefabsContent", menuName = "Content/PrefabsContent")]
    public class PrefabsContent : ScriptableObject
    {
        [field: SerializeField] public GameFieldView GameFieldView { get; private set; }
        [field: SerializeField] public TileView TileView { get; private set; }
    }
}