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
            var directions = new Vector2Int[4] { Vector2Int.left, Vector2Int.right, Vector2Int.up, Vector2Int.down };
            foreach(var index in _filter)
            {
                var turnEvent = _filter.Get1(index);
                foreach(var selectedTile in turnEvent.SelectedTiles)
                {
                    var matches = FindMatches(selectedTile, directions);
                    if(matches.Count >= 3)
                    {
                        _world.SendMessage(new MatchEvent { MatchPositions = matches });
                    }
                }
            }
        }

        private List<Vector2Int> FindMatches(Vector2Int startPosition, Vector2Int[] directions)
        {
            var matches = new List<Vector2Int> { startPosition };

            foreach(var direction in directions)
            {
                var currentPosition = startPosition + direction;
                while (_gameFieldModel.IsInside(currentPosition) && (_gameFieldModel[currentPosition].State == _gameFieldModel[startPosition].State))
                {
                    matches.Add(direction);
                    currentPosition += direction;
                }
            }

            return matches;
        }
    }
}