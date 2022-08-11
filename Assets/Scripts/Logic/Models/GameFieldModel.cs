using UnityEngine;

public class GameFieldModel
{
    private readonly TileModel[,] _tiles;

    public GameFieldModel(GameFieldDescription gameFieldDescription)
    {
        EmptyTileState = gameFieldDescription.EmptyFieldState;
        MaxTileState = gameFieldDescription.MaxState;
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

    public int EmptyTileState { get; private set; }
    public int MaxTileState { get; private set; }
    public int Width => _tiles.GetLength(0);
    public int Height => _tiles.GetLength(1);
    public TileModel this[Vector2Int position] => _tiles[position.x, position.y];
    public TileModel this[int x, int y] => _tiles[x, y];
    public bool IsInside(Vector2Int position) => position.x >= 0 && position.x < Width && position.y >= 0 && position.y < Height;
    public bool IsAdjacent(Vector2Int firstPos, Vector2Int secondPos)
    {
        var dx = Mathf.Abs(secondPos.x - firstPos.x);
        var dy = Mathf.Abs(secondPos.y - firstPos.y);
        return dx + dy == 1;
    }
}
