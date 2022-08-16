using Assets.Scripts.Logic.Components.Gameplay;
using Assets.Scripts.Logic.Components.Tiles;
using Assets.Scripts.Logic.Extensions;
using Assets.Scripts.Logic.Models;
using Leopotam.Ecs;
using Logic.MatchCheckers;
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
                var firstMatches =
                    _matchChecker.CheckMatches(_gameFieldModel, clickedTile.Position, selectedTile.State);
                var secondMatches =
                    _matchChecker.CheckMatches(_gameFieldModel, selectedTile.Position, clickedTile.State);
                if (firstMatches || secondMatches)
                {
                    _world.SendMessage<TurnEvent>();
                    (selectedTile.State, clickedTile.State) = (clickedTile.State, selectedTile.State);
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
    }
}