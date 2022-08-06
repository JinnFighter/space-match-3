using Leopotam.Ecs;
using UnityEngine;

namespace Assets.Scripts.Logic.Systems.GameField
{
    public class InitGameFieldSystem : IEcsInitSystem
    {
        private readonly GameFieldModel _gameFieldModel;
        private readonly GameFieldDescription _gameFieldDescription;

        public void Init()
        {
            for (var i = 0; i < _gameFieldModel.Width; i++)
            {
                for (var j = 0; j < _gameFieldModel.Height; j++)
                {
                    _gameFieldModel.Tiles[i, j].State = Random.Range(_gameFieldDescription.EmptyFieldState + 1, _gameFieldDescription.MaxState);
                }
            }
        }
    }
}