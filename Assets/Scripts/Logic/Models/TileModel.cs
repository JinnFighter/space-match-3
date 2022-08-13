using System;
using UnityEngine;

public class TileModel
{
    public Vector2Int Position;

    private int _state;
    public int State
    {
        get => _state;
        set
        {
            if(_state != value)
            {
                _state = value;
                StateChanged?.Invoke(_state);
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
    public event Action<int> StateChanged;
}
