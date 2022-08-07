using Assets.Scripts.Logic.Generators;
using Leopotam.Ecs;

namespace Assets.Scripts.Logic.Systems.GameField
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
                    _gameFieldModel[i, j].State = gameField[i, j];
                }
            }
        }
    }
}