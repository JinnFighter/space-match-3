using Assets.Scripts.Logic.Components.Tiles;
using Assets.Scripts.Logic.Models;
using Leopotam.Ecs;
using UnityEngine;

namespace Assets.Scripts.Logic.Systems.Tiles
{
    public class SetTileSelectionSystem : IEcsRunSystem
    {
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
                        Deselect();
                        Select(tile.Position);
                    }
                }
                else
                {
                    Select(tile.Position);
                }
            }
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