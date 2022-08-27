using Leopotam.Ecs;
using Logic.Generators;
using Logic.Models;

namespace Logic.Systems.GameField
{
    public class InitGameFieldSystem : IEcsInitSystem
    {
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
                    
                    tileModel.Color = gameField[i, j];
                }
            }
        }
    }
}