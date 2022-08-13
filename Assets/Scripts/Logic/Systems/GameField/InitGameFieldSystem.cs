using Assets.Scripts.Logic.Components.Tiles;
using Assets.Scripts.Logic.Generators;
using Leopotam.Ecs;

namespace Assets.Scripts.Logic.Systems.GameField
{
    public class InitGameFieldSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;
        private readonly GameFieldModel _gameFieldModel = null;
        private readonly IGameFieldGenerator _gameFieldGenerator = null;

        public void Init()
        {
            var gameField = _gameFieldGenerator.GenerateGameField(_gameFieldModel.Width, _gameFieldModel.Height);

            for (var i = 0; i < _gameFieldModel.Width; i++)
            {
                for (var j = 0; j < _gameFieldModel.Height; j++)
                {
                    var tileModel = _gameFieldModel[i, j];

                    tileModel.State = gameField[i, j];

                    var tileEntity = _world.NewEntity();
                    ref var tile = ref tileEntity.Get<Tile>();
                    tile.Position = tileModel.Position;
                    tile.State = tileModel.State;
                }
            }
        }
    }
}