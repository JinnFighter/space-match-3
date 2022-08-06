using UnityEngine;

public class GameFieldModel
{
    private readonly TileModel[,] _tiles;

    public GameFieldModel(GameFieldDescription gameFieldDescription)
    {
        _tiles = new TileModel[gameFieldDescription.Width, gameFieldDescription.Height];
        for(var i = 0; i < gameFieldDescription.Width; i++)
        {
            for (var j = 0; j < gameFieldDescription.Height; j++)
            {
                _tiles[i, j] = new TileModel
                {
                    IsSelected = false,
                    Position = new UnityEngine.Vector2Int(i, j),
                    State = gameFieldDescription.EmptyFieldState
                };
            }
        }
    }

    public int Width => _tiles.GetLength(0);
    public int Height => _tiles.GetLength(1);
    public TileModel this[Vector2Int position] => _tiles[position.x, position.y];
    public TileModel this[int x, int y] => _tiles[x, y];
}