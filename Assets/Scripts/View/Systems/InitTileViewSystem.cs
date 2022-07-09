using Assets.Scripts.Common;
using Assets.Scripts.Logic.Models;
using Assets.Scripts.View.Components;
using Assets.Scripts.View.Content;
using Leopotam.Ecs;
using UnityEngine;

namespace Assets.Scripts.View.Systems
{
    public class InitTileViewSystem : IEcsInitSystem
    {
        private readonly EcsWorld _ecsWorld = null;
        private readonly GameFieldModel _gameFieldModel = null;
        private readonly ViewContainer _viewContainer = null;
        private readonly PrefabsContent _prefabsContainer = null;

        public void Init()
        {
            var gameFieldView = Object.Instantiate(_prefabsContainer.GameFieldView, _viewContainer.GameplayCanvas.transform);

            for(var i = 0; i < _gameFieldModel.Width; i++)
            {
                for (var j = 0; j < _gameFieldModel.Height; j++)
                {
                    var entity = _ecsWorld.NewEntity();
                    ref var tileViewModel = ref entity.Get<TileViewModel>();
                    tileViewModel.Position = new Vector2Int(i, j);

                    ref var tileViewContainer = ref entity.Get<TileViewContainer>();
                    tileViewContainer.TileView = Object.Instantiate(_prefabsContainer.TileView, gameFieldView.transform);
                }
            }
        }
    }
}