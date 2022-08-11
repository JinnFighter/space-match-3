using Assets.Scripts.Logic.Components.Ui;
using Assets.Scripts.Logic.Models;
using Leopotam.Ecs;

namespace Assets.Scripts.Logic.Systems.Ui
{
    public class UpdateTurnCountViewSystem : IEcsRunSystem
    {
        private readonly EcsFilter<TurnCountViewContainer> _filter = null;
        private readonly TurnCountModel _turnCountModel = null;

        public void Run()
        {
            foreach(var index in _filter)
            {
                ref var turnCountViewContainer = ref _filter.Get1(index);
                if(turnCountViewContainer.TurnCount != _turnCountModel.TurnCount)
                {
                    turnCountViewContainer.TurnCount = _turnCountModel.TurnCount;
                    turnCountViewContainer.TurnCountView.SetTurnCount(turnCountViewContainer.TurnCount);
                }
            }
        }
    }
}