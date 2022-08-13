using Assets.Scripts.Logic.Descriptions;
using Assets.Scripts.Logic.Models;
using Assets.Scripts.Logic.Views;
using Zenject;

namespace Assets.Scripts.Logic.Presenters
{
    public class TilePresenter : IPresenter
    {
        private readonly TileModel _tileModel;
        private readonly TileClickInputModel _tileClickInputModel;
        private readonly GameFieldDescription _gameFieldDescription;
        private readonly TileColorsDescription _tileColorsDescription;

        private readonly TileView _tileView;

        public TilePresenter(TileModel tileModel,  TileClickInputModel tileClickInputModel, GameFieldDescription gameFieldDescription, TileColorsDescription tileColorsDescription, TileView tileView)
        {
            _tileModel = tileModel;
            _tileClickInputModel = tileClickInputModel;
            _gameFieldDescription = gameFieldDescription;
            _tileColorsDescription = tileColorsDescription;
            _tileView = tileView;
        }

        public void Disable()
        {
            _tileModel.StateChanged -= OnStateChanged;
            _tileModel.IsSelectedChanged -= OnIsSelectedChanged;
            _tileView.ClickedEvent -= OnTileClicked;
        }

        public void Enable()
        {
            _tileModel.StateChanged += OnStateChanged;
            _tileModel.IsSelectedChanged += OnIsSelectedChanged;
            _tileView.ClickedEvent += OnTileClicked;

            _tileView.SetColor(_tileColorsDescription[_tileModel.State]);
            if (_tileModel.IsSelected)
            {
                _tileView.Select();
            }
        }

        private void OnTileClicked()
        {
            _tileClickInputModel.ClickedTilePosition = _tileModel.Position;
        }

        private void OnIsSelectedChanged(bool isSelected)
        {
            if (isSelected)
            {
                _tileView.Select();
            }
            else
            {
                _tileView.Deselect();
            }
        }

        private void OnStateChanged(int state)
        {
            if (state == _gameFieldDescription.EmptyFieldState)
            {
                _tileView.DisableBall();
            }
            else
            {
                _tileView.EnableBall();
                _tileView.SetColor(_tileColorsDescription[state]);
            }
        }
    }
}