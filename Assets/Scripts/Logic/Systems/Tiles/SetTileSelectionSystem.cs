using Assets.Scripts.Logic.Components.Tiles;
using Leopotam.Ecs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Logic.Systems.Tiles
{
    public class SetTileSelectionSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Tile, TileClicked> _clickedFilter = null;
        private readonly EcsFilter<Tile, TileSelected> _selectedFilter = null;
        private readonly GameFieldModel _gameFieldModel = null;

        public void Run()
        {
            foreach(var index in _clickedFilter)
            {
                var tile = _clickedFilter.Get1(index);
                var entity = _clickedFilter.GetEntity(index);
                if (_selectedFilter.IsEmpty())
                {
                    Select(tile.Position, entity);
                }
                else 
                {
                    if (entity.Has<TileSelected>())
                    {
                        Deselect();
                    }
                    else
                    {
                        Deselect();
                        Select(tile.Position, entity);
                    }
                }
            }
        }

        private void Select(Vector2Int tilePosition, EcsEntity entity)
        {
            _gameFieldModel.Tiles[tilePosition.x, tilePosition.y].IsSelected = true;
            entity.Get<TileSelected>();
        }

        private void Deselect()
        {
            foreach (var index in _selectedFilter)
            {
                var tile = _selectedFilter.Get1(index);
                _gameFieldModel.Tiles[tile.Position.x, tile.Position.y].IsSelected = false;
                var entity = _selectedFilter.GetEntity(index);
                entity.Del<TileSelected>();
            }
        }
    }
}