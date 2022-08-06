using Assets.Scripts.Common;
using Assets.Scripts.Logic.Components.Tiles;
using Assets.Scripts.Logic.Views;
using Leopotam.Ecs;
using UnityEngine;

namespace Assets.Scripts.Logic.Systems.GameField
{
    public class InitGameFieldViewSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;
        private readonly GameFieldModel _gameFieldModel = null;
        private readonly ViewContainer _viewContainer = null;
        private readonly GameFieldView _gameFieldPrefab = null;
        private readonly TileView _tilePrefab = null;

        public void Init()
        {
            var gameFieldView = Object.Instantiate(_gameFieldPrefab, _viewContainer.GameplayCanvas.transform);
            var parentTransform = gameFieldView.transform;

            for (int i = 0; i < _gameFieldModel.Width; i++)
            {
                for (int j = 0; j < _gameFieldModel.Height; j++)
                {
                    var tileView = Object.Instantiate(_tilePrefab, parentTransform);
                    var tileEntity = _world.NewEntity();
                    ref var tile = ref tileEntity.Get<Tile>();
                    tile.Position = new Vector2Int(i, j);
                    tile.State = _gameFieldModel.Tiles[i, j].State;
                    tileView.SetState(tile.State);
                    ref var tileViewContainer = ref tileEntity.Get<TileViewContainer>();
                    tileViewContainer.TileView = tileView;
                }
            }
        }
    }
}