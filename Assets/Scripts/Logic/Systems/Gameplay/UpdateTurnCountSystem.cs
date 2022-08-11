using Assets.Scripts.Logic.Components.Gameplay;
using Assets.Scripts.Logic.Models;
using Leopotam.Ecs;
using UnityEngine;

namespace Assets.Scripts.Logic.Systems.Gameplay
{
    public class UpdateTurnCountSystem : IEcsRunSystem
    {
        private readonly EcsFilter<TurnEvent> _filter = null;
        private readonly TurnCountModel _turnCountModel = null;

        public void Run()
        {
            if(!_filter.IsEmpty())
            {
                _turnCountModel.TurnCount--;
                if(_turnCountModel.TurnCount == 0)
                {
                    Debug.Log("Game Over!");
                }
            }
        }
    }
}