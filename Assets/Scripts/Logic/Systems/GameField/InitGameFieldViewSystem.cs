using Assets.Scripts.Common;
using Assets.Scripts.Logic.Views;
using Leopotam.Ecs;
using UnityEngine;

namespace Assets.Scripts.Logic.Systems.GameField
{
    public class InitGameFieldViewSystem : IEcsInitSystem
    {
        private readonly GameFieldModel _gameFieldModel;
        private readonly ViewContainer _viewContainer;
        private readonly GameFieldView _gameFieldPrefab;
        private readonly TileView _tilePrefab;

        public void Init()
        {
            var gameFieldView = Object.Instantiate(_gameFieldPrefab, _viewContainer.GameplayCanvas.transform);
            var parentTransform = gameFieldView.transform;

            for (int i = 0; i < _gameFieldModel.Width; i++)
            {
                for (int j = 0; j < _gameFieldModel.Height; j++)
                {
                    var tileView = Object.Instantiate(_tilePrefab, parentTransform);
                }
            }
        }
    }
}