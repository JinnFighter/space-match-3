using Assets.Scripts.Common;
using Assets.Scripts.Logic.Components;
using Assets.Scripts.View.Components;
using Assets.Scripts.View.Content;
using Leopotam.Ecs;
using UnityEngine;

namespace Assets.Scripts.View.Systems
{
    public class InitTileViewSystem : IEcsInitSystem
    {
        private readonly EcsFilter<Tile> _filter = null;

        private readonly ViewContainer _viewContainer = null;
        private readonly PrefabsContent _prefabsContainer = null;

        public void Init()
        {
            var gameFieldView = Object.Instantiate(_prefabsContainer.GameFieldView, _viewContainer.GameplayCanvas.transform);
            foreach(var index in _filter)
            {
                var entity = _filter.GetEntity(index);
                ref var tileViewModel = ref entity.Get<TileViewModel>();

                ref var tileViewContainer = ref entity.Get<TileViewContainer>();
                tileViewContainer.TileView = Object.Instantiate(_prefabsContainer.TileView, gameFieldView.transform);
            }
        }
    }
}