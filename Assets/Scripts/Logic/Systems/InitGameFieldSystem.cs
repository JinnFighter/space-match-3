using Assets.Scripts.Logic.Components;
using Assets.Scripts.Logic.Models;
using Leopotam.Ecs;

namespace Assets.Scripts.Logic.Systems
{
    public class InitGameFieldSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;

        private readonly GameFieldModel _gameFieldModel = null;

        void IEcsInitSystem.Init()
        {
            _gameFieldModel.Tiles = new int[10, 10];

            for (int i = 0; i < _gameFieldModel.Width; i++)
            {
                for (int j = 0; j < _gameFieldModel.Height; j++)
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