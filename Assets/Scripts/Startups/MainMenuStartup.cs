using UnityEngine;
using VContainer;

public class MainMenuStartup : MonoBehaviour
{
    [Inject] private MainMenuPresenter _mainMenuPresenter;
    
    void Start()
    {
       _mainMenuPresenter.Enable(); 
    }

    void OnDestroy()
    {
        _mainMenuPresenter.Disable();
    }
}
