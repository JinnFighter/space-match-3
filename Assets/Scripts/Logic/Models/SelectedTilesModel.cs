using UnityEngine;

public class SelectedTilesModel : MonoBehaviour
{
    public Vector2Int OutsidePosition { get; } = new (-1, -1);
    private Vector2Int _lastSelected;
    public Vector2Int LastSelected
    {
        get => _lastSelected;
        set
        {
            _lastSelected = value;
            LastSelectedChanged?.Invoke(_lastSelected);
        }
    }

    private Vector2Int _currentSelection = new(-1, -1);
    public Vector2Int CurrentSelection
    {
        get => _currentSelection;
        set
        {
            _currentSelection = value;
            CurrentSelectionChanged?.Invoke(_currentSelection);
        }
    }

    public delegate void Vector2IntChange(Vector2Int value);
    public event Vector2IntChange LastSelectedChanged;
    public event Vector2IntChange CurrentSelectionChanged;
}
