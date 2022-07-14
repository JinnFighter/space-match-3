using UnityEngine;

namespace Assets.Scripts.Logic.Models
{
    public class TileModel
    {
        private Vector2Int _position = new(-1, -1);
        public Vector2Int Position
        {
            get { return _position; }
            set
            {
                _position = value;
                PositionChanged?.Invoke(_position);
            }
        }

        public delegate void Vector2IntChange(Vector2Int value);
        public event Vector2IntChange PositionChanged;
    }
}