using UnityEngine;

namespace Assets.Scripts.Logic.Models
{
    public class TileModel
    {
        private Vector2Int _position = new(-1, -1);
        public Vector2Int Position
        {
            get => _position;
            set
            {
                _position = value;
                PositionChanged?.Invoke(_position);
            }
        }

        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set 
            {
                if(_isSelected != value)
                {
                    _isSelected = value;
                    IsSelectedChanged?.Invoke(_isSelected);
                }
            }
        }

        public delegate void Vector2IntChange(Vector2Int value);
        public delegate void BoolChange(bool value);
        public event Vector2IntChange PositionChanged;
        public event BoolChange IsSelectedChanged;
    }
}