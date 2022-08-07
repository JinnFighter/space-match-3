using Assets.Scripts.Common;
using Assets.Scripts.Logic.Components.Tiles;
using Assets.Scripts.Logic.Generators;
using Assets.Scripts.Logic.Models;
using Assets.Scripts.Logic.Views;
using System;
using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    [SerializeField] private GameFieldDescription _gameFieldDescription;

    [SerializeField] private GameFieldView _gameFieldView;
    [SerializeField] private TileView _tileView;
    [SerializeField] private ViewContainer _viewContainer;

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
        Container.Bind<IGameFieldGenerator>().To<RandomGameFieldGenerator>().AsTransient();
    }

    private void BindScene()
    {
        Container.Bind<ViewContainer>().FromInstance(_viewContainer).AsSingle();
    }

    private void BindPrefabs()
    {
        Container.Bind<GameFieldView>().FromInstance(_gameFieldView).AsTransient();
        Container.Bind<TileView>().FromInstance(_tileView).AsTransient();
    }

    private void BindDescriptions()
    {
        Container.Bind<GameFieldDescription>().FromScriptableObject(_gameFieldDescription).AsSingle();
    }

    private void BindModels()
    {
        Container.Bind<GameFieldModel>().AsSingle().NonLazy();
        Container.Bind<TileSelectionModel>().AsSingle().NonLazy();
    }
}
