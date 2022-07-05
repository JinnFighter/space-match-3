using Assets.Scripts.Logic.Components;
using Leopotam.Ecs;

namespace Assets.Scripts.Logic.Systems
{
    public class InitGameFieldSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;

        void IEcsInitSystem.Init()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    var entity = _world.NewEntity();
                    ref var tile = ref entity.Get<Tile>();
                    tile.Position = new UnityEngine.Vector2Int(i, j);
                    tile.State = -1;
                }
            }
        }
    }
}