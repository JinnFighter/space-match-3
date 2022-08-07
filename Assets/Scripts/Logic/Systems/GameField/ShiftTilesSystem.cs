using Assets.Scripts.Logic.Components.Gameplay;
using Leopotam.Ecs;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Logic.Systems.GameField
{
    public class ShiftTilesSystem : IEcsRunSystem
    {
        private readonly EcsFilter<MatchEvent> _filter = null;
        private readonly GameFieldModel _gameFieldModel = null;
        private readonly GameFieldDescription _gameFieldDescription = null;

        public void Run()
        {
            foreach(var index in _filter)
            {
                var match = _filter.Get1(index);
                foreach(var tilePosition in match.MatchPositions)
                {
                    ShiftTiles(tilePosition);
                }
            }
        }

        private void ShiftTiles(Vector2Int startPosition)
        {
            var emptyCount = 0;
            var tileColumn = new List<Vector2Int>();
            for (int y = startPosition.y; y < _gameFieldModel.Height; y++)
            {
                var tile = _gameFieldModel[startPosition.x, y];
                if(tile.State == _gameFieldDescription.EmptyFieldState)
                {
                    emptyCount++;
                }
                tileColumn.Add(tile.Position);
            }

            for (int i = 0; i < emptyCount; i++)
            {
                for (int j = 0; j < tileColumn.Count - 1; j++)
                {
                    _gameFieldModel[tileColumn[j]].State = _gameFieldModel[tileColumn[j + 1]].State;
                    _gameFieldModel[tileColumn[j + 1]].State = _gameFieldDescription.EmptyFieldState;

                }
            }
        }
    }
}