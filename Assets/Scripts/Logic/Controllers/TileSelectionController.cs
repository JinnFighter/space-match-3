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
            if(IsInside(value))
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
                        if(IsAdjacent(_selectedTilesModel.CurrentSelection, value))
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

        private bool IsAdjacent(Vector2Int firstPos, Vector2Int secondPos)
        {
            bool IsAdjacentExceptDiagonal(Vector2Int firstPos, Vector2Int secondPos)
            {
                var dx = Mathf.Abs(firstPos.x - secondPos.x);
                var dy = Mathf.Abs(firstPos.y - secondPos.y);
                return dx <= 1 && dy <= 1 && (dx + dy) % 2 == 1;
            }

            return firstPos != secondPos && IsAdjacentExceptDiagonal(firstPos, secondPos);
        }

        private bool IsInside(Vector2Int position) => position.x >= 0 && position.x < _gameFieldModel.Width && position.y >= 0 && position.y < _gameFieldModel.Height;
    }
}