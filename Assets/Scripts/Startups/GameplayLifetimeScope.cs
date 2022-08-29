using Assets.Scripts.Common;
using Assets.Scripts.Logic.Descriptions;
using Assets.Scripts.Logic.Models;
using Assets.Scripts.Logic.Presenters;
using Assets.Scripts.Logic.Views;
using Logic.Descriptions;
using Logic.Generators;
using Logic.MatchCheckers;
using Logic.Models;
using Logic.Presenters;
using Logic.Views;
using Startups.LogicContainers;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameplayLifetimeScope : LifetimeScope
{
    [SerializeField] private GameFieldDescription _gameFieldDescription;
    [SerializeField] private TileColorsDescription _tileColorsDescription;
    [SerializeField] private LevelDescription _levelDescription;

    [SerializeField] private GameFieldView _gameFieldView;
    [SerializeField] private TileView _tileView;
    [SerializeField] private UiView _uiView;

    [SerializeField] private ViewContainer _viewContainer;
    [SerializeField] private GameOverView _gameOverView;
    
    protected override void Configure(IContainerBuilder builder)
    {
        BindDescriptions(builder);
        BindModels(builder);
        BindHelpers(builder);
        BindPrefabs(builder);
        BindScene(builder);
        BindPresenters(builder);
        BindLogicContainers(builder);
    }

    private void BindDescriptions(IContainerBuilder builder)
    {
        builder.RegisterInstance<GameFieldDescription>(_gameFieldDescription);
        builder.RegisterInstance<TileColorsDescription>(_tileColorsDescription);
        builder.RegisterInstance<LevelDescription>(_levelDescription);
    }
    
    private void BindModels(IContainerBuilder builder)
    {
        builder.Register<GameStateModel>(Lifetime.Singleton);
        builder.Register<TileClickInputModel>(Lifetime.Singleton);
        builder.Register<GameFieldModel>(Lifetime.Singleton);
        builder.Register<TileSelectionModel>(Lifetime.Singleton);
        builder.Register<ScoreModel>(Lifetime.Singleton);
        builder.Register<TurnCountModel>(Lifetime.Singleton);
    }
    
    private void BindHelpers(IContainerBuilder builder)
    {
        builder.Register<IGameFieldGenerator, RandomGameFieldGenerator>(Lifetime.Transient);
        builder.Register<IMatchChecker, MatchChecker>(Lifetime.Singleton);
    }
    
    private void BindPrefabs(IContainerBuilder builder)
    {
        builder.RegisterInstance<TileView>(_tileView);
    }
    
    private void BindScene(IContainerBuilder builder)
    {
        builder.RegisterInstance<ViewContainer>(_viewContainer);
        builder.RegisterInstance<GameFieldView>(_gameFieldView);
        builder.RegisterInstance<ScoreView>(_uiView.ScoreView);
        builder.RegisterInstance<TurnCountView>(_uiView.TurnCountView);
        builder.RegisterInstance<GameOverView>(_gameOverView);
    }
    
    private void BindPresenters(IContainerBuilder builder)
    {
        builder.Register<GameFieldPresenter>(Lifetime.Singleton);
        builder.Register<ScorePresenter>(Lifetime.Singleton);
        builder.Register<TurnCountPresenter>(Lifetime.Singleton);
        builder.Register<GameOverPresenter>(Lifetime.Singleton);

        builder.Register<PresenterContainer>(Lifetime.Singleton);
    }
    
    private void BindLogicContainers(IContainerBuilder builder)
    {
        builder.Register<EcsLogicContainer>(Lifetime.Singleton);
        builder.Register<PresenterLogicContainer>(Lifetime.Singleton);
    }
}
