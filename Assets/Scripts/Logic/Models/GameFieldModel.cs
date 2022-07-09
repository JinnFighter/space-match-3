namespace Assets.Scripts.Logic.Models
{
    public class GameFieldModel
    {
        public int[,] Tiles;

        public int Width => Tiles.GetLength(0);
        public int Height => Tiles.GetLength(1);
    }
}