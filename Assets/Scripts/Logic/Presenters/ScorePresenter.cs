using Assets.Scripts.Logic.Models;
using Assets.Scripts.Logic.Presenters;
using Assets.Scripts.Logic.Views;
using Zenject;

public class ScorePresenter : IPresenter
{
    [Inject]
    private readonly ScoreModel _scoreModel;
    [Inject]
    private readonly ScoreView _scoreView;

    public void Disable()
    {
        _scoreModel.ScoreChanged -= OnScoreChanged;
    }

    public void Enable()
    {
        _scoreModel.ScoreChanged += OnScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        _scoreView.SetScore(score);
    }
}
