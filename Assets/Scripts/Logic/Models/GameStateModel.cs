using System;

public class GameStateModel
{
    private bool _isActive = true;

    public bool IsActive
    {
        get => _isActive;
        set
        {
            if (_isActive != value)
            {
                _isActive = value;
                IsActiveChanged?.Invoke(_isActive);
            }
        }
    }

    public void InvokeGameOver()
    {
        IsActive = false;
        GameOverEvent?.Invoke();
    }

    public Action<bool> IsActiveChanged;
    public Action GameOverEvent;
}
