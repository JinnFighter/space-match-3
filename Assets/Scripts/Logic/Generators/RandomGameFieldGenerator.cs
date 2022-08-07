using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Logic.Generators
{
    public class RandomGameFieldGenerator : IGameFieldGenerator
    {
        private readonly GameFieldDescription _gameFieldDescription;

        public int[,] GenerateGameField(int width, int height)
        {
            var gameField = new int[width, height];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    gameField[i, j] = Random.Range(_gameFieldDescription.EmptyFieldState + 1, _gameFieldDescription.MaxState);
                }
            }
            return gameField;
        }
    }
}