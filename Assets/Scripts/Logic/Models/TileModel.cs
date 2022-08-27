using System;
using UnityEngine;

namespace Logic.Models
{
    public class TileModel
    {
        public Vector2Int Position;

        private Color _color;
        public Color Color
        {
            get => _color;
            set
            {
                if (_color != value)
                {
                    _color = value;
                    ColorChanged?.Invoke(_color);
                }
            }
        }

        private bool _hasBall;

        public bool HasBall
        {
            get => _hasBall;
            set
            {
                if (_hasBall != value)
                {
                    _hasBall = value;
                    HasBallChanged?.Invoke(_hasBall);
                }
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

        public event Action<bool> IsSelectedChanged;
        public event Action<Color> ColorChanged;
        public event Action<bool> HasBallChanged;
    }
}
