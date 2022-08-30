using UnityEngine;
using VContainer;
using VContainer.Unity;

public class MainMenuLifetimeScope : LifetimeScope
{
    [SerializeField] private MainMenuView _mainMenuView;
    
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterInstance<MainMenuView>(_mainMenuView);

        builder.Register<MainMenuPresenter>(Lifetime.Singleton);
    }
}
