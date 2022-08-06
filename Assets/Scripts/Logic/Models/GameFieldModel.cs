public class GameFieldModel
{
    public readonly int[,] Tiles;

    public GameFieldModel(GameFieldDescription gameFieldDescription)
    {
        Tiles = new int[gameFieldDescription.Width, gameFieldDescription.Height];
        for(var i = 0; i < gameFieldDescription.Width; i++)
        {
            for (var j = 0; j < gameFieldDescription.Height; j++)
            {
                Tiles[i, j] = gameFieldDescription.EmptyFieldState;
            }
        }
    }

    public int Width => Tiles.GetLength(0);
    public int Height => Tiles.GetLength(1);
}
