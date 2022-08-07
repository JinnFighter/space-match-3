using UnityEngine;

namespace Assets.Scripts.Logic.Models
{
    public class TileSelectionModel
    {
        private Vector2Int _notSelectedTile = new(-1, -1);
        public Vector2Int SelectedTile { get; private set; } = new(-1, -1);
        public bool HasSelection => SelectedTile != _notSelectedTile;
        public void Select(Vector2Int position) => SelectedTile = position;
        public void Deselect() => SelectedTile = _notSelectedTile;
    }
}