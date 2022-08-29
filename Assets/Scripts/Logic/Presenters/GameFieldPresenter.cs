using Assets.Scripts.Logic.Models;
using Assets.Scripts.Logic.Presenters;
using Assets.Scripts.Logic.Views;
using Logic.Models;
using Logic.Views;
using UnityEngine;
using VContainer;

namespace Logic.Presenters
{
    public class GameFieldPresenter : IPresenter
    {
        [Inject] private readonly GameFieldModel _gameFieldModel;
        [Inject] private readonly TileClickInputModel _tileClickInputModel;
        [Inject] private readonly GameFieldView _gameFieldView;
        [Inject] private readonly TileView _tilePrefab;

        private IPresenter[,] _presenters;

        public void Disable()
        {
            foreach(var presenter in _presenters)
            {
                presenter.Disable();
            }
        }

        public void Enable()
        {
            _presenters = new IPresenter[_gameFieldModel.Width, _gameFieldModel.Height];
            var layoutTransform = _gameFieldView.Layout.transform;

            for (var i = 0; i < _gameFieldModel.Width; i++)
            {
                for (var j = 0; j < _gameFieldModel.Height; j++)
                {
                    var view = Object.Instantiate(_tilePrefab, layoutTransform);

                    var presenter = new TilePresenter(_gameFieldModel[i, j], _tileClickInputModel, view);
                    _presenters[i, j] = presenter;
                    presenter.Enable();
                }
            }
        }
    }
}