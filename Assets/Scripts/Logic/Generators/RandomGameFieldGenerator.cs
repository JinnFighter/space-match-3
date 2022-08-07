using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Logic.Generators
{
    public class RandomGameFieldGenerator : IGameFieldGenerator
    {
        private readonly GameFieldDescription _gameFieldDescription;

        public RandomGameFieldGenerator(GameFieldDescription gameFieldDescription)
        {
            _gameFieldDescription = gameFieldDescription;
        }

        public int[,] GenerateGameField(int width, int height)
        {
            var gameField = new int[width, height];

            var prevLeft = new int[height];
            var prevBelow = -1;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    var possibleStates = Enumerable.Range(_gameFieldDescription.EmptyFieldState + 1, _gameFieldDescription.MaxState).ToList();
                    possibleStates.Remove(prevLeft[j]);
                    possibleStates.Remove(prevBelow);
                    gameField[i, j] = possibleStates[Random.Range(0, possibleStates.Count)];

                    prevLeft[j] = gameField[i, j];
                    prevBelow = gameField[i, j];
                }
            }
            return gameField;
        }
    }
}