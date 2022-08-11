using Assets.Scripts.Logic.Components.Gameplay;
using Assets.Scripts.Logic.Models;
using Leopotam.Ecs;

namespace Assets.Scripts.Logic.Systems.Gameplay
{
    public class AddScoreOnMatchSystem : IEcsRunSystem
    {
        private readonly EcsFilter<MatchEvent> _filter = null;
        private readonly ScoreModel _scoreModel = null;

        public void Run()
        {
            foreach(var index in _filter)
            {
                var matchEvent = _filter.Get1(index);
                _scoreModel.Score += matchEvent.MatchPositions.Count * 10;
            }
        }
    }
}