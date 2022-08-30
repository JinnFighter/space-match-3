using Assets.Scripts.Logic.Models;
using Assets.Scripts.Logic.Presenters;
using Assets.Scripts.Logic.Views;
using VContainer;

public class ScorePresenter : IPresenter
{
    private readonly ScoreModel _scoreModel;
    private readonly ScoreView _scoreView;

    [Inject]
    public ScorePresenter(ScoreModel scoreModel, ScoreView scoreView)
    {
        _scoreModel = scoreModel;
        _scoreView = scoreView;
    }

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
