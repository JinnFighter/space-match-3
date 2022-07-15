using UnityEngine;

namespace Assets.Scripts.Logic.Models
{
    public class GameFieldModel
    {
        public TileModel[,] Tiles;

        public int Width => Tiles.GetLength(0);
        public int Height => Tiles.GetLength(1);

        public bool IsInside(Vector2Int position) => position.x >= 0 && position.x < Width && position.y >= 0 && position.y < Height;
    }
}