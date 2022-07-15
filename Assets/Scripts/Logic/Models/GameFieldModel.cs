using UnityEngine;

namespace Assets.Scripts.Logic.Models
{
    public class GameFieldModel
    {
        public TileModel[,] Tiles;

        public int Width => Tiles.GetLength(0);
        public int Height => Tiles.GetLength(1);

        public bool IsInside(Vector2Int position) => position.x >= 0 && position.x < Width && position.y >= 0 && position.y < Height;

        public bool IsAdjacent(Vector2Int firstPos, Vector2Int secondPos) => firstPos != secondPos && IsInside(firstPos) && IsInside(secondPos) && Mathf.Abs(firstPos.x - secondPos.x) <= 1 && Mathf.Abs(firstPos.y - secondPos.y) <= 1;
    }
}