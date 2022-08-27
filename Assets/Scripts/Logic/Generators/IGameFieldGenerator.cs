using UnityEngine;

namespace Logic.Generators
{
    public interface IGameFieldGenerator
    {
        Color[,] GenerateGameField(int width, int height);
    }
}