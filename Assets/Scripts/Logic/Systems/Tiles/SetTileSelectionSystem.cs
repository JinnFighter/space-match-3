using Assets.Scripts.Logic.Components.Gameplay;
using Assets.Scripts.Logic.Components.Tiles;
using Assets.Scripts.Logic.Extensions;
using Assets.Scripts.Logic.Models;
using Leopotam.Ecs;
using System;
using UnityEngine;

namespace Assets.Scripts.Logic.Systems.Tiles
{
    public class SetTileSelectionSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<Tile, TileClicked> _filter = null;
        private readonly GameFieldModel _gameFieldModel = null;
        private readonly TileSelectionModel _tileSelectionModel = null;

        public void Run()
        {
            foreach(var index in _filter)
            {
                var tile = _filter.Get1(index);

                if(_tileSelectionModel.HasSelection)
                {
                    if (_tileSelectionModel.SelectedTile == tile.Position)
                    {
                        Deselect();
                    }
                    else
                    {
                        SwapStates(tile.Position);
                        Deselect();
                    }
                }
                else
                {
                    Select(tile.Position);
                }
            }
        }

        private void SwapStates(Vector2Int position)
        {
            var selectedTile = _gameFieldModel[_tileSelectionModel.SelectedTile];
            var clickedTile = _gameFieldModel[position];

            if(_gameFieldModel.IsInside(selectedTile.Position) && _gameFieldModel.IsInside(clickedTile.Position) && _gameFieldModel.IsAdjacent(selectedTile.Position, clickedTile.Position))
            {
                (selectedTile.State, clickedTile.State) = (clickedTile.State, selectedTile.State);
                _world.SendMessage<TurnEvent>();
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