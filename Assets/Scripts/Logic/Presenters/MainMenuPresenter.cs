using Assets.Scripts.Logic.Presenters;
using UnityEngine.SceneManagement;
using VContainer;

public class MainMenuPresenter : IPresenter
{
    private readonly MainMenuView _mainMenuView;

    [Inject]
    public MainMenuPresenter(MainMenuView mainMenuView)
    {
        _mainMenuView = mainMenuView;
    }

    public void Disable()
    {
        _mainMenuView.PlayButton.onClick.RemoveListener(OnPlayButtonClicked);
    }

    public void Enable()
    {
        _mainMenuView.PlayButton.onClick.AddListener(OnPlayButtonClicked);
    }

    private void OnPlayButtonClicked()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
