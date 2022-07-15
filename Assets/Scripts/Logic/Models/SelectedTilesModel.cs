using UnityEngine;

public class SelectedTilesModel : MonoBehaviour
{
    private Vector2Int _outsidePosition = new(-1, -1);
    private Vector2Int _selectedPosition;
    public Vector2Int SelectedPosition
    {
        get => _selectedPosition;
        set
        {
            _selectedPosition = value;
            SelectedPositionChanged?.Invoke(_selectedPosition);
        }
    }

    public bool HasSelected() => _selectedPosition != _outsidePosition;

    public delegate void Vector2IntChange(Vector2Int value);
    public event Vector2IntChange SelectedPositionChanged;
}
