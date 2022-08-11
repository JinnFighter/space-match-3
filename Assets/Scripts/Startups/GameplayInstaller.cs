using Assets.Scripts.Common;
using Assets.Scripts.Logic.Generators;
using Assets.Scripts.Logic.Models;
using Assets.Scripts.Logic.Views;
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
    }

    private void BindModels()
    {
        Container.Bind<GameFieldModel>().AsSingle().NonLazy();
        Container.Bind<TileSelectionModel>().AsSingle().NonLazy();
        Container.Bind<ScoreModel>().AsSingle().NonLazy();
        Container.Bind<TurnCountModel>().AsSingle().NonLazy();
    }
}
