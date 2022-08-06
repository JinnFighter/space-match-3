using Assets.Scripts.Logic.Views;
using System;
using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    [SerializeField] private GameFieldDescription _gameFieldDescription;

    [SerializeField] private GameFieldView _gameFieldView;
    [SerializeField] private TileView _tileView;

    public override void InstallBindings()
    {
        BindDescriptions();
        BindModels();
        BindPrefabs();
    }

    private void BindPrefabs()
    {
        Container.Bind<GameFieldView>().FromComponentInNewPrefab(_gameFieldView).AsTransient();
        Container.Bind<TileView>().FromComponentInNewPrefab(_tileView).AsTransient();
    }

    private void BindDescriptions()
    {
        Container.Bind<GameFieldDescription>().FromScriptableObject(_gameFieldDescription).AsSingle();
    }

    private void BindModels()
    {
        Container.Bind<GameFieldModel>().AsSingle().NonLazy();
    }
}
