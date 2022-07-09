using Assets.Scripts.Logic.Components;
using Assets.Scripts.View.Components;
using Leopotam.Ecs;

namespace Assets.Scripts.View.Systems
{
    public class UpdateTileViewStateSystem : IEcsRunSystem
    {
        private readonly EcsFilter<Tile, TileViewModel, TileViewContainer> _filter = null;

        public void Run()
        {
            foreach(var index in _filter)
            {
                var tile = _filter.Get1(index);
                var viewModel = _filter.Get2(index);
                var viewContainer = _filter.Get3(index);
                if(viewModel.State != tile.State)
                {
                    viewModel.State = tile.State;
                    viewContainer.TileView.SetState(viewModel.State);
                }
            }
        }
    }
}