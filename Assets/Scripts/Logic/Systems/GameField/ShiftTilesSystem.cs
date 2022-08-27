using Assets.Scripts.Logic.Components.Gameplay;
using Assets.Scripts.Logic.Extensions;
using Leopotam.Ecs;
using System.Collections.Generic;
using Assets.Scripts.Logic.Descriptions;
using Logic.Models;
using UnityEngine;

namespace Assets.Scripts.Logic.Systems.GameField
{
    public class ShiftTilesSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<MatchEvent> _filter = null;

        private readonly GameFieldModel _gameFieldModel = null;
        private readonly TileColorsDescription _tileColorsDescription = null;

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
            var validColors = new Stack<Color>();
            for (var x = 0; x < _gameFieldModel.Height; x++)
            {
                var tile = _gameFieldModel[x, y];
                if (tile.HasBall)
                {
                    validColors.Push(tile.Color);
                }
                else
                {
                    emptyCount++;
                }
            }

            if (emptyCount > 0)
            {
                for (var x = _gameFieldModel.Height - 1; x > 0; x--)
                {
                    var tile = _gameFieldModel[x, y];
                    if (validColors.Count > 0)
                    {
                        tile.Color = validColors.Pop();
                        tile.HasBall = true;
                    }
                    else
                    {
                        tile.HasBall = false;
                    }
                }

                for (var i = 0; i < emptyCount; i++)
                {
                    var tile = _gameFieldModel[i, y];
                    tile.Color = GetNewColor(tile.Position);
                    tile.HasBall = true;
                }
            }
        }

        private Color GetNewColor(Vector2Int position)
        {
            var possibleCharacters = new List<Color>(_tileColorsDescription.Colors);

            if (position.x > 0)
            {
                possibleCharacters.Remove(_gameFieldModel[position.x - 1, position.y].Color);
            }

            if (position.x < _gameFieldModel.Width - 1)
            {
                possibleCharacters.Remove(_gameFieldModel[position.x + 1, position.y].Color);
            }

            if (position.y > 0)
            {
                possibleCharacters.Remove(_gameFieldModel[position.x, position.y - 1].Color);
            }

            return possibleCharacters[Random.Range(0, possibleCharacters.Count)];
        }
    }
}