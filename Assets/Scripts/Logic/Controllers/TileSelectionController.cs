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
                if(_selectedTilesModel.CurrentSelection == _selectedTilesModel.NoSelection)
                {
                    _selectedTilesModel.CurrentSelection = value;
                    _gameFieldModel.Tiles[value.x, value.y].IsSelected = true;
                }
                else
                {
                    if(_selectedTilesModel.CurrentSelection == value)
                    {
                        _selectedTilesModel.CurrentSelection = _selectedTilesModel.NoSelection;
                        _gameFieldModel.Tiles[value.x, value.y].IsSelected = false;
                    }
                    else
                    {
                        if(_gameFieldModel.IsAdjacent(_selectedTilesModel.CurrentSelection, value))
                        {
                            _gameFieldModel.Tiles[_selectedTilesModel.CurrentSelection.x, _selectedTilesModel.CurrentSelection.y].IsSelected = false;

                            SwapTiles(_gameFieldModel.Tiles[value.x, value.y], _gameFieldModel.Tiles[_selectedTilesModel.CurrentSelection.x, _selectedTilesModel.CurrentSelection.y]);

                            _selectedTilesModel.CurrentSelection = _selectedTilesModel.NoSelection;
                        }
                        else
                        {
                            _gameFieldModel.Tiles[_selectedTilesModel.CurrentSelection.x, _selectedTilesModel.CurrentSelection.y].IsSelected = false;
                            _selectedTilesModel.CurrentSelection = value;
                            _gameFieldModel.Tiles[value.x, value.y].IsSelected = true;
                        }
                    }
                }
            }
        }

        private void SwapTiles(TileModel first, TileModel second)
        {
            (second.State, first.State) = (first.State, second.State);
        }
    }
}