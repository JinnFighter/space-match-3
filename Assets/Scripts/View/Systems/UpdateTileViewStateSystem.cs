using Assets.Scripts.Logic.Models;
using Assets.Scripts.View.Components;
using Leopotam.Ecs;

namespace Assets.Scripts.View.Systems
{
    public class UpdateTileViewStateSystem : IEcsRunSystem
    {
        private readonly EcsFilter<TileViewModel, TileViewContainer> _filter = null;
        private readonly GameFieldModel _gameFieldModel = null;

        public void Run()
        {
            foreach(var index in _filter)
            {
                var viewModel = _filter.Get1(index);
                var viewContainer = _filter.Get2(index);
                if(viewModel.State != _gameFieldModel.Tiles[viewModel.Position.x, viewModel.Position.y])
                {
                    viewModel.State = _gameFieldModel.Tiles[viewModel.Position.x, viewModel.Position.y];
                    viewContainer.TileView.SetState(viewModel.State);
                }
            }
        }
    }
}