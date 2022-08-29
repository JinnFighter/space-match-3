using Assets.Scripts.Logic.Presenters;
using Assets.Scripts.Logic.Views;
using VContainer;

public class GameOverPresenter : IPresenter
{
    [Inject] private readonly GameStateModel _gameStateModel;
    [Inject] private readonly GameOverView _gameOverView;
    
    public void Disable()
    {
        _gameStateModel.GameOverEvent -= OnGameOverEvent;
        if (!_gameStateModel.IsActive)
        {
            HideGameOverScreen();
        }
    }

    public void Enable()
    {
        _gameStateModel.GameOverEvent += OnGameOverEvent;
        if (!_gameStateModel.IsActive)
        {
            ShowGameOverScreen();
        }
    }

    private void OnGameOverEvent()
    {
        ShowGameOverScreen();
    }

    private void ShowGameOverScreen()
    {
        _gameOverView.GameObject.SetActive(true);
    }

    private void HideGameOverScreen()
    {
        _gameOverView.GameObject.SetActive(false);
    }
}
