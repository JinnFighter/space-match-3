using Assets.Scripts.Logic.Components.Gameplay;
using Leopotam.Ecs;

namespace Assets.Scripts.Logic.Systems.GameField
{
    public class ClearMatchedTileSystem : IEcsRunSystem
    {
        private readonly EcsFilter<MatchEvent> _filter = null;
        private readonly GameFieldModel _gameFieldModel = null;
        private readonly GameFieldDescription _gameFieldDescription = null;

        public void Run()
        {
            foreach (var index in _filter)
            {
                var matchEvent = _filter.Get1(index);
                foreach(var matchPosition in matchEvent.MatchPositions)
                {
                    _gameFieldModel[matchPosition].State = _gameFieldDescription.EmptyFieldState;
                }
            }
        }
    }
}