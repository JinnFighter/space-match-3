using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Logic.Descriptions
{
    [CreateAssetMenu(fileName = "TileColorsDescription", menuName = "Descriptions/TileColorsDescription")]
    public class TileColorsDescription : ScriptableObject
    {
        [field: SerializeField] public Color DefaultColor { get; private set; } = new Color(255, 255, 255, 0);
        [field: SerializeField]
        public List<Color> Colors { get; private set; } = new List<Color>
        {
            Color.white,
            Color.red,
            Color.blue,
            Color.yellow,
            Color.green,
            Color.black,
        };
        public Color this[int index] => index >= 0 ? index < Colors.Count ? Colors[index] : DefaultColor : DefaultColor;
    }
}