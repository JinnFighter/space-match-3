using Assets.Scripts.Logic.Components.Ui;
using Assets.Scripts.Logic.Models;
using Leopotam.Ecs;

namespace Assets.Scripts.Logic.Systems.Ui
{
    public class UpdateScoreViewSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ScoreViewContainer> _filter = null;
        private readonly ScoreModel _scoreModel = null;

        public void Run()
        {
            foreach(var index in _filter)
            {
                ref var scoreViewContainer = ref _filter.Get1(index);
                if(_scoreModel.Score != scoreViewContainer.Score)
                {
                    scoreViewContainer.Score = _scoreModel.Score;
                    scoreViewContainer.ScoreView.SetScore(scoreViewContainer.Score);
                }
            }
        }
    }
}