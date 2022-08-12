using Assets.Scripts.Common;
using Assets.Scripts.Logic.Descriptions;
using Assets.Scripts.Logic.Generators;
using Assets.Scripts.Logic.Models;
using Assets.Scripts.Logic.Presenters;
using Assets.Scripts.Logic.Views;
using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    [SerializeField] private GameFieldDescription _gameFieldDescription;
    [SerializeField] private TileColorsDescription _tileColorsDescription;
    [SerializeField] private LevelDescription _levelDescription;

    [SerializeField] private GameFieldView _gameFieldView;
    [SerializeField] private TileView _tileView;
    [SerializeField] private UiView _uiView;

    [SerializeField] private ViewContainer _viewContainer;

    public override void InstallBindings()
    {
        BindDescriptions();
        BindModels();
        BindHelpers();
        BindPrefabs();
        BindScene();
        BindPresenters();
    }

    private void BindPresenters()
    {
        Container.Bind<ScorePresenter>().AsSingle();
        Container.Bind<TurnCountPresenter>().AsSingle();

        Container.Bind<PresenterContainer>().AsSingle();
    }

    private void BindHelpers()
    {
        Container.Bind<IGameFieldGenerator>().To<RandomGameFieldGenerator>().AsTransient().NonLazy();
    }

    private void BindScene()
    {
        Container.Bind<ViewContainer>().FromInstance(_viewContainer).AsSingle();
        Container.Bind<GameFieldView>().FromInstance(_gameFieldView).AsTransient();
        Container.Bind<ScoreView>().FromInstance(_uiView.ScoreView).AsSingle();
        Container.Bind<TurnCountView>().FromInstance(_uiView.TurnCountView).AsSingle();
    }

    private void BindPrefabs()
    {
        Container.Bind<TileView>().FromInstance(_tileView).AsTransient();
    }

    private void BindDescriptions()
    {
        Container.Bind<GameFieldDescription>().FromScriptableObject(_gameFieldDescription).AsSingle();
        Container.Bind<TileColorsDescription>().FromScriptableObject(_tileColorsDescription).AsSingle();
        Container.Bind<LevelDescription>().FromScriptableObject(_levelDescription).AsSingle();
    }

    private void BindModels()
    {
        Container.Bind<GameFieldModel>().AsSingle().NonLazy();
        Container.Bind<TileSelectionModel>().AsSingle().NonLazy();
        Container.Bind<ScoreModel>().AsSingle().NonLazy();
        Container.Bind<TurnCountModel>().AsSingle().NonLazy();
    }
}
