using Assets.Scripts.Logic.Models;
using Leopotam.Ecs;

namespace Assets.Scripts.Logic.Systems
{
    public class InitGameFieldSystem : IEcsInitSystem
    {
        private readonly GameFieldModel _gameFieldModel = null;
        private readonly GameFieldDescription _gameFieldDescription = null;

        void IEcsInitSystem.Init()
        {
            _gameFieldModel.Tiles = new int[_gameFieldDescription.Width, _gameFieldDescription.Height];

            for (int i = 0; i < _gameFieldModel.Width; i++)
            {
                for (int j = 0; j < _gameFieldModel.Height; j++)
                {
                    _gameFieldModel.Tiles[i, j] = -1;
                }
            }
        }
    }
}