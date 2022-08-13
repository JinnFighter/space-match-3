using Assets.Scripts.Logic.Models;
using Leopotam.Ecs;

namespace Assets.Scripts.Logic.Systems.Input
{
    public class ClearInputModelsSystem : IEcsRunSystem
    {
        private readonly TileClickInputModel _tileClickInputModel = null;

        public void Run()
        {
            _tileClickInputModel.ClearInput();
        }
    }
}