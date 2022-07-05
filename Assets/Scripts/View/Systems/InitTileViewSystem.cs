using Assets.Scripts.Logic.Components;
using Assets.Scripts.View.Components;
using Leopotam.Ecs;

namespace Assets.Scripts.View.Systems
{
    public class InitTileViewSystem : IEcsInitSystem
    {
        private readonly EcsFilter<Tile> _filter = null;

        public void Init()
        {
            foreach(var index in _filter)
            {
                var entity = _filter.GetEntity(index);
                ref var tileViewModel = ref entity.Get<TileViewModel>();
                tileViewModel.State = -1;
            }
        }
    }
}