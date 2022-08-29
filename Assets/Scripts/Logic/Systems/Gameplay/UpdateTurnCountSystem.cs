using Assets.Scripts.Logic.Components.Gameplay;
using Assets.Scripts.Logic.Extensions;
using Assets.Scripts.Logic.Models;
using Leopotam.Ecs;

namespace Assets.Scripts.Logic.Systems.Gameplay
{
    public class UpdateTurnCountSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<TurnEvent> _filter = null;
        private readonly TurnCountModel _turnCountModel = null;
        private readonly GameStateModel _gameStateModel = null;

        public void Run()
        {
            if(!_filter.IsEmpty())
            {
                _turnCountModel.TurnCount--;
                if(_turnCountModel.TurnCount == 0)
                {
                    _world.SendMessage<GameOverEvent>();
                    _gameStateModel.InvokeGameOver();
                }
            }
        }
    }
}