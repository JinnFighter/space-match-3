using UnityEngine;

namespace Assets.Scripts.Logic.Models
{
    public class TileClickInputModel : IInputModel
    {
        private Vector2Int _clickedTilePosition;
        public Vector2Int ClickedTilePosition
        {
            get => _clickedTilePosition;
            set
            {
                _clickedTilePosition = value;
                HasNewInput = true;
            }
        }
        public bool HasNewInput { get; private set; }

        public void ClearInput()
        {
            HasNewInput = false;
        }
    }
}