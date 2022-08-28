using Assets.Scripts.Logic.Models;
using Assets.Scripts.Logic.Presenters;
using Logic.Models;
using Logic.Views;
using UnityEngine;

namespace Logic.Presenters
{
    public class TilePresenter : IPresenter
    {
        private readonly TileModel _tileModel;
        private readonly TileClickInputModel _tileClickInputModel;

        private readonly TileView _tileView;

        public TilePresenter(TileModel tileModel,  TileClickInputModel tileClickInputModel, TileView tileView)
        {
            _tileModel = tileModel;
            _tileClickInputModel = tileClickInputModel;
            _tileView = tileView;
        }

        public void Disable()
        {
            _tileModel.HasBallChanged -= OnHasBallChanged;
            _tileModel.ColorChanged -= OnColorChanged;
            _tileModel.IsSelectedChanged -= OnIsSelectedChanged;
            _tileView.ClickedEvent -= OnTileClicked;
        }

        public void Enable()
        {
            _tileModel.HasBallChanged += OnHasBallChanged;
            _tileModel.ColorChanged += OnColorChanged;
            _tileModel.IsSelectedChanged += OnIsSelectedChanged;
            _tileView.ClickedEvent += OnTileClicked;

            _tileView.BallView.SetColor(_tileModel.Color);
            if (_tileModel.IsSelected)
            {
                _tileView.BallView.Select();
            }
        }

        private void OnColorChanged(Color color)
        {
            _tileView.BallView.SetColor(color);
        }

        private void OnTileClicked()
        {
            _tileClickInputModel.ClickedTilePosition = _tileModel.Position;
        }

        private void OnIsSelectedChanged(bool isSelected)
        {
            if (isSelected)
            {
                _tileView.BallView.Select();
            }
            else
            {
                _tileView.BallView.Deselect();
            }
        }

        private void OnHasBallChanged(bool hasBall)
        {
            if (hasBall)
            {
                _tileView.BallView.GameObject.SetActive(true);
            }
            else
            {
                _tileView.BallView.GameObject.SetActive(false);
            }
        }
    }
}