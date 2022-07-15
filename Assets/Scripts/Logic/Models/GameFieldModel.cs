using UnityEngine;

namespace Assets.Scripts.Logic.Models
{
    public class GameFieldModel
    {
        public TileModel[,] Tiles;

        public int Width => Tiles.GetLength(0);
        public int Height => Tiles.GetLength(1);

        public bool IsInside(Vector2Int position) => position.x >= 0 && position.x < Width && position.y >= 0 && position.y < Height;

        public bool IsAdjacent(Vector2Int firstPos, Vector2Int secondPos)
        {
            bool IsAdjacentExceptDiagonal (Vector2Int firstPos, Vector2Int secondPos)
            {
                var dx = Mathf.Abs(firstPos.x - secondPos.x);
                var dy = Mathf.Abs(firstPos.y - secondPos.y);
                return dx <= 1 && dy <= 1 && (dx + dy) % 2 == 1;
            }

            return firstPos != secondPos && IsInside(firstPos) && IsInside(secondPos) && IsAdjacentExceptDiagonal(firstPos, secondPos);
        }
    }
}