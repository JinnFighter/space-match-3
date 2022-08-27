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
            foreach(var _ in _filter)
            {
                for (var i = 0; i < _gameFieldModel.Height; i++)
                {
                    ShiftTilesDown(i);
                }

                _world.SendMessage<CheckMatchRequest>();
            }
        }

        private void ShiftTilesDown(int y)
        {
            var emptyCount = 0;
            var validStates = new Stack<int>();
            for (var x = 0; x < _gameFieldModel.Height; x++)
            {
                var tile = _gameFieldModel[x, y];
                if(tile.State == _gameFieldModel.EmptyTileState)
                {
                    emptyCount++;
                }
                else
                {
                    validStates.Push(tile.State);
                }
            }

            if (emptyCount > 0)
            {
                for (var x = _gameFieldModel.Height - 1; x > 0; x--)
                {
                    var tile = _gameFieldModel[x, y];
                    tile.State = validStates.Count > 0 ? validStates.Pop() : _gameFieldModel.EmptyTileState;
                }

                for (var i = 0; i < emptyCount; i++)
                {
                    var tile = _gameFieldModel[i, y];
                    tile.State = GetNewState(tile.Position);
                }
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