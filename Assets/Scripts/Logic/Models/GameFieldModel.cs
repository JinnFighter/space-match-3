public class GameFieldModel
{
    public readonly int[,] Tiles;
    public GameFieldModel(GameFieldDescription gameFieldDescription)
    {
        Tiles = new int[gameFieldDescription.Width, gameFieldDescription.Height];
    }
}
