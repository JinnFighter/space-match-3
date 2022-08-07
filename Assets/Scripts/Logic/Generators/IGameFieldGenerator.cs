namespace Assets.Scripts.Logic.Generators
{
    public interface IGameFieldGenerator
    {
        int[,] GenerateGameField(int width, int height);
    }
}