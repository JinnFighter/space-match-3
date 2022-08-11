using Assets.Scripts.Common;
using Assets.Scripts.Logic.Descriptions;
using Assets.Scripts.Logic.Generators;
using Assets.Scripts.Logic.Models;
using Assets.Scripts.Logic.Presenters;
using Assets.Scripts.Logic.Views;
using System;
using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller, IInitializable, IDisposable
{
    [SerializeField] private GameFieldDescription _gameFieldDescription;
    [SerializeField] private TileColorsDescription _tileColorsDescription;

    [SerializeField] private GameFieldView _gameFieldView;
    [SerializeField] private TileView _tileView;

    [SerializeField] private ViewContainer _viewContainer;

    private PresenterContainer _presenterContainer = new();

    public override void InstallBindings()
    {
        BindDescriptions();
        BindModels();
        BindHelpers();
        BindPrefabs();
        BindScene();
    }

    private void BindHelpers()
    {
        Container.Bind<IGameFieldGenerator>().To<RandomGameFieldGenerator>().AsTransient().NonLazy();
    }

    private void BindScene()
    {
        Container.Bind<ViewContainer>().FromInstance(_viewContainer).AsSingle();
        Container.Bind<GameFieldView>().FromInstance(_gameFieldView).AsTransient();
    }

    private void BindPrefabs()
    {
        Container.Bind<TileView>().FromInstance(_tileView).AsTransient();
    }

    private void BindDescriptions()
    {
        Container.Bind<GameFieldDescription>().FromScriptableObject(_gameFieldDescription).AsSingle();
        Container.Bind<TileColorsDescription>().FromScriptableObject(_tileColorsDescription).AsSingle();
    }

    private void BindModels()
    {
        Container.Bind<GameFieldModel>().AsSingle().NonLazy();
        Container.Bind<TileSelectionModel>().AsSingle().NonLazy();
        Container.Bind<ScoreModel>().AsSingle().NonLazy();
        Container.Bind<TurnCountModel>().AsSingle().NonLazy();
    }

    public void Initialize()
    {
        _presenterContainer.Enable();
    }

    public void Dispose()
    {
        _presenterContainer.Disable();
        _presenterContainer.Clear();
    }
}
