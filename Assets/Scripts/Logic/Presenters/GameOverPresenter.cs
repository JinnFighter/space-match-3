using Assets.Scripts.Logic.Presenters;
using Assets.Scripts.Logic.Views;
using UnityEngine.SceneManagement;
using VContainer;

public class GameOverPresenter : IPresenter
{
    private readonly GameStateModel _gameStateModel;
    private readonly GameOverView _gameOverView;

    [Inject]
    public GameOverPresenter(GameStateModel gameStateModel, GameOverView gameOverView)
    {
        _gameStateModel = gameStateModel;
        _gameOverView = gameOverView;
    }

    public void Disable()
    {
        _gameOverView.RestartButton.onClick.RemoveListener(OnRestartButtonClicked);
        _gameStateModel.GameOverEvent -= OnGameOverEvent;
        if (!_gameStateModel.IsActive)
        {
            HideGameOverScreen();
        }
    }

    public void Enable()
    {
        _gameOverView.RestartButton.onClick.AddListener(OnRestartButtonClicked);
        _gameStateModel.GameOverEvent += OnGameOverEvent;
        if (!_gameStateModel.IsActive)
        {
            ShowGameOverScreen();
        }
    }

    private void OnRestartButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
