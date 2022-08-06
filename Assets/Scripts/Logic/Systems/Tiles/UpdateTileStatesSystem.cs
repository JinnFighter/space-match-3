using Assets.Scripts.Logic.Components.Tiles;
using Leopotam.Ecs;

namespace Assets.Scripts.Logic.Systems.Tiles
{
    public class UpdateTileStatesSystem : IEcsRunSystem
    {
        private readonly EcsFilter<TileViewContainer> _filter = null;
        private readonly GameFieldModel _gameFieldModel = null;

        public void Run()
        {
            foreach(var index in _filter)
            {
                var tileViewContainer = _filter.Get1(index);
                tileViewContainer.TileView.SetState(0);
            }
        }
    }
}