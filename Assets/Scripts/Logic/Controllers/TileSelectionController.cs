using Assets.Scripts.Common;
using Assets.Scripts.Logic.Models;
using UnityEngine;

namespace Assets.Scripts.Logic.Controllers
{
    public class TileSelectionController : IController
    {
        private readonly GameFieldModel _gameFieldModel;
        private readonly SelectedTilesModel _selectedTilesModel;

        public TileSelectionController(GameFieldModel gameFieldModel, SelectedTilesModel selectedTilesModel)
        {
            _gameFieldModel = gameFieldModel;
            _selectedTilesModel = selectedTilesModel;
        }

        public void Disable()
        {
            _selectedTilesModel.LastSelectedChanged -= OnSelectedPositionChanged;
        }

        public void Enable()
        {
            _selectedTilesModel.LastSelectedChanged += OnSelectedPositionChanged;
        }

        private void OnSelectedPositionChanged(Vector2Int value)
        {
            if(_gameFieldModel.IsInside(value))
            {
                _gameFieldModel.Tiles[value.x, value.y].IsSelected = true;
            }
        }
    }
}