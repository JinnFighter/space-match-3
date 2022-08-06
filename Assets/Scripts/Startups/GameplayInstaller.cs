using System;
using UnityEngine;
using Zenject;

public class GameplayInstaller : MonoInstaller
{
    [SerializeField] private GameFieldDescription _gameFieldDescription;
    public override void InstallBindings()
    {
        BindDescriptions();
        BindModels();
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
