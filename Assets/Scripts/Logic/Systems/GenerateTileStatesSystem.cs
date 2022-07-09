using Assets.Scripts.Logic.Models;
using Leopotam.Ecs;
using UnityEngine;

namespace Assets.Scripts.Logic.Systems
{
    public class GenerateTileStatesSystem : IEcsInitSystem
    {
        private readonly GameFieldModel _gameFieldModel = null;
        private readonly TileStatesDescription _tileStatesDescription = null;

        public void Init()
        {
            for(var i = 0; i < _gameFieldModel.Width; i++)
            {
                for(var j = 0; j < _gameFieldModel.Height; j++)
                {
                    _gameFieldModel.Tiles[i, j] = Random.Range(_tileStatesDescription.EmptyFieldState, _tileStatesDescription.MaxState);
                }
            }
        }
    }
}