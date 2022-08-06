using Assets.Scripts.Logic.Components.Tiles;
using Leopotam.Ecs;

namespace Assets.Scripts.Logic.Systems.Tiles
{
    public class CheckTileClickedSystem : IEcsRunSystem
    {
        private readonly EcsFilter<TileViewContainer> _filter = null;

        public void Run()
        {
            foreach(var index in _filter)
            {
                var tileView = _filter.Get1(index);
                if(tileView.TileView.IsClicked)
                {
                    tileView.TileView.ResetClicked();
                    var entity = _filter.GetEntity(index);
                    entity.Get<TileClicked>();
                }
            }
        }
    }
}