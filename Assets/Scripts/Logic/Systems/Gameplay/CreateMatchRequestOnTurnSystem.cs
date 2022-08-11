using Assets.Scripts.Logic.Components.Gameplay;
using Assets.Scripts.Logic.Extensions;
using Leopotam.Ecs;

namespace Assets.Scripts.Logic.Systems.Gameplay
{
    public class CreateMatchRequestOnTurnSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<TurnEvent> _filter = null;

        public void Run()
        {
            foreach(var _ in _filter)
            {
                _world.SendMessage<CheckMatchRequest>();
            }
        }
    }
}