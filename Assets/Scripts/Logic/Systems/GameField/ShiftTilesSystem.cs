using Assets.Scripts.Logic.Components.Gameplay;
using Assets.Scripts.Logic.Extensions;
using Leopotam.Ecs;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Logic.Systems.GameField
{
    public class ShiftTilesSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<MatchEvent> _filter = null;

        private readonly GameFieldModel _gameFieldModel = null;

        public void Run()
        {
            foreach(var index in _filter)
            {
                var match = _filter.Get1(index);
                foreach(var tilePosition in match.MatchPositions)
                {
                    ShiftTiles(tilePosition);
                }

                _world.SendMessage<CheckMatchRequest>();
            }
        }

        private void ShiftTiles(Vector2Int startPosition)
        {
            var emptyCount = 0;
            var tileColumn = new List<Vector2Int>();
            for (int y = startPosition.y; y < _gameFieldModel.Height; y++)
            {
                var tile = _gameFieldModel[startPosition.x, y];
                if(tile.State == _gameFieldModel.EmptyTileState)
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
                    _gameFieldModel[tileColumn[j + 1]].State = _gameFieldModel.EmptyTileState;
                }
            }

            for (var i = 0; i < emptyCount; i++)
            {
                var tile = _gameFieldModel[tileColumn[tileColumn.Count - 1 - i]];
                tile.State = GetNewState(tile.Position);
            }
        }

        private int GetNewState(Vector2Int position)
        {
            var possibleCharacters = Enumerable.Range(_gameFieldModel.EmptyTileState + 1, _gameFieldModel.MaxTileState).ToList();

            if (position.x > 0)
            {
                possibleCharacters.Remove(_gameFieldModel[position.x - 1, position.y].State);
            }

            if (position.x < _gameFieldModel.Width - 1)
            {
                possibleCharacters.Remove(_gameFieldModel[position.x + 1, position.y].State);
            }

            if (position.y > 0)
            {
                possibleCharacters.Remove(_gameFieldModel[position.x, position.y - 1].State);
            }

            return possibleCharacters[Random.Range(0, possibleCharacters.Count)];
        }
    }
}