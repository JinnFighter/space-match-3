using Assets.Scripts.Logic.Components.Gameplay;
using Assets.Scripts.Logic.Extensions;
using Leopotam.Ecs;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Logic.Systems.GameField
{
    public class CheckMatchesSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<TurnEvent> _filter = null;
        private readonly GameFieldModel _gameFieldModel = null;

        public void Run()
        {
            if(!_filter.IsEmpty())
            {
                var directions = new Vector2Int[4] { Vector2Int.left, Vector2Int.right, Vector2Int.up, Vector2Int.down };
                var visitStates = new bool[_gameFieldModel.Width, _gameFieldModel.Height];
                for (var i = 0; i < _gameFieldModel.Width; i++)
                {
                    for (int j = 0; j < _gameFieldModel.Height; j++)
                    {
                        var matches = GetMatches(_gameFieldModel[i, j].Position, directions, visitStates);
                        if (matches.Count >= 3)
                        {
                            _world.SendMessage(new MatchEvent { MatchPositions = matches });
                        }
                    }
                }
            }
        }

        private List<Vector2Int> GetMatches(Vector2Int startPosition, Vector2Int[] directions, bool[,] visitStates)
        {
           var matches = new List<Vector2Int> { startPosition };
           visitStates[startPosition.x, startPosition.y] = true;
           
           foreach(var direction in directions)
           {
                var currentPosition = startPosition + direction;
                if(_gameFieldModel.IsInside(currentPosition) && !visitStates[currentPosition.x, currentPosition.y] && _gameFieldModel[currentPosition].State == _gameFieldModel[startPosition].State)
                {
                    matches.AddRange(GetMatches(currentPosition, directions, visitStates));
                }
           }

           return matches;
        }
    }
}