using Assets.Scripts.Logic.Components.Gameplay;
using Leopotam.Ecs;
using Logic.Models;

namespace Logic.Systems.GameField
{
    public class ClearMatchedTileSystem : IEcsRunSystem
    {
        private readonly EcsFilter<MatchEvent> _filter = null;
        private readonly GameFieldModel _gameFieldModel = null;

        public void Run()
        {
            foreach (var index in _filter)
            {
                var matchEvent = _filter.Get1(index);
                foreach(var matchPosition in matchEvent.MatchPositions)
                {
                    _gameFieldModel[matchPosition].HasBall = false;
                }
            }
        }
    }
}