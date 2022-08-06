using Assets.Scripts.Logic.Components.Tiles;
using Leopotam.Ecs;

namespace Assets.Scripts.Logic.Systems.Tiles
{
    public class UpdateTileStatesSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Tile, TileViewContainer> _filter = null;
        private readonly GameFieldModel _gameFieldModel = null;

        public void Run()
        {
            foreach(var index in _filter)
            {
                ref var tile = ref _filter.Get1(index);
                var tileViewContainer = _filter.Get2(index);

                var tileModel = _gameFieldModel[tile.Position];
                if(tile.State != tileModel.State)
                {
                    tile.State = tileModel.State;
                    tileViewContainer.TileView.SetState(tile.State);
                }
            }
        }
    }
}