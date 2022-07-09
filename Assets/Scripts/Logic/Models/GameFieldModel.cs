namespace Assets.Scripts.Logic.Models
{
    public class GameFieldModel
    {
        public readonly int[,] Tiles;

        public GameFieldModel(int width, int height)
        {
            Tiles = new int[width, height];
            for (var i = 0; i < Height; i++)
            {
                for (var j = 0; j < Width; j++)
                {
                    Tiles[i, j] = -1;
                }
            }
        }

        public int Width => Tiles.GetLength(0);
        public int Height => Tiles.GetLength(1);
    }
}