using System.Collections.Generic;
using Assets.Scripts.Logic.Descriptions;
using UnityEngine;

namespace Logic.Generators
{
    public class RandomGameFieldGenerator : IGameFieldGenerator
    {
        private readonly TileColorsDescription _tileColorsDescription;

        public RandomGameFieldGenerator(TileColorsDescription tileColorsDescription)
        {
            _tileColorsDescription = tileColorsDescription;
        }

        public Color[,] GenerateGameField(int width, int height)
        {
            var gameField = new Color[width, height];

            var prevLeft = new Color[height];
            var prevBelow = _tileColorsDescription.DefaultColor;

            for (var i = 0; i < width; i++)
            {
                for (var j = 0; j < height; j++)
                {
                    var possibleColors = new List<Color>(_tileColorsDescription.Colors);
                    possibleColors.Remove(prevLeft[j]);
                    possibleColors.Remove(prevBelow);
                    gameField[i, j] = possibleColors[Random.Range(0, possibleColors.Count)];

                    prevLeft[j] = gameField[i, j];
                    prevBelow = gameField[i, j];
                }
            }
            return gameField;
        }
    }
}