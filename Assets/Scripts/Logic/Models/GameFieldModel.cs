public class GameFieldModel
{
    public readonly TileModel[,] Tiles;

    public GameFieldModel(GameFieldDescription gameFieldDescription)
    {
        Tiles = new TileModel[gameFieldDescription.Width, gameFieldDescription.Height];
        for(var i = 0; i < gameFieldDescription.Width; i++)
        {
            for (var j = 0; j < gameFieldDescription.Height; j++)
            {
                Tiles[i, j] = new TileModel
                {
                    IsSelected = false,
                    Position = new UnityEngine.Vector2Int(i, j),
                    State = gameFieldDescription.EmptyFieldState
                };
            }
        }
    }

    public int Width => Tiles.GetLength(0);
    public int Height => Tiles.GetLength(1);
}
