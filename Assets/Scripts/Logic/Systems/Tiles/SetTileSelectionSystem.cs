using System.Linq;
using Assets.Scripts.Logic.Components.Gameplay;
using Assets.Scripts.Logic.Components.Tiles;
using Assets.Scripts.Logic.Extensions;
using Assets.Scripts.Logic.Models;
using Leopotam.Ecs;
using Logic.MatchCheckers;
using Logic.Models;
using UnityEngine;

namespace Logic.Systems.Tiles
{
    public class SetTileSelectionSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<TileClicked> _filter = null;
        private readonly GameFieldModel _gameFieldModel = null;
        private readonly TileSelectionModel _tileSelectionModel = null;
        private readonly TurnCountModel _turnCountModel = null;
        private readonly IMatchChecker _matchChecker = null;
        
        private readonly Vector2Int[] _horizontalDirections = new Vector2Int[2] { Vector2Int.left, Vector2Int.right };
        private readonly Vector2Int[] _verticalDirections = new Vector2Int[2] { Vector2Int.up, Vector2Int.down };

        public void Run()
        {
            foreach(var index in _filter)
            {
                var tileClicked = _filter.Get1(index);

                if(_tileSelectionModel.HasSelection)
                {
                    if (_tileSelectionModel.SelectedTile == tileClicked.TilePosition)
                    {
                        Deselect();
                    }
                    else
                    {
                        SwapStates(tileClicked.TilePosition);
                        Deselect();
                    }
                }
                else
                {
                    Select(tileClicked.TilePosition);
                }
            }
        }

        private void SwapStates(Vector2Int position)
        {
            var selectedTile = _gameFieldModel[_tileSelectionModel.SelectedTile];
            var clickedTile = _gameFieldModel[position];

            if(_gameFieldModel.IsAdjacent(selectedTile.Position, clickedTile.Position) && _turnCountModel.TurnCount > 0)
            {
                var firstMatches = HasMatches(clickedTile.Position, selectedTile.Position, selectedTile.Color);
                var secondMatches = HasMatches(selectedTile.Position, clickedTile.Position, clickedTile.Color);
                
                if (firstMatches || secondMatches)
                {
                    _world.SendMessage<TurnEvent>();
                    (selectedTile.Color, clickedTile.Color) = (clickedTile.Color, selectedTile.Color);
                }
            }; 
        }

        private void Select(Vector2Int tilePosition)
        {
            _gameFieldModel[tilePosition].IsSelected = true;
            _tileSelectionModel.Select(tilePosition);
        }

        private void Deselect()
        {
            _gameFieldModel[_tileSelectionModel.SelectedTile].IsSelected = false;
            _tileSelectionModel.Deselect();
        }

        private bool HasMatches(Vector2Int checkedTile, Vector2Int adjacentTile, Color color)
        {
            var excludedDirection = adjacentTile - checkedTile;

            var horDirections = _horizontalDirections.Where(dir => dir != excludedDirection);
            var vertDirections = _verticalDirections.Where(dir => dir != excludedDirection);
            
            return _matchChecker.CheckMatches(_gameFieldModel, checkedTile, horDirections, color) || 
                   _matchChecker.CheckMatches(_gameFieldModel, checkedTile, vertDirections, color);
        }
    }
}