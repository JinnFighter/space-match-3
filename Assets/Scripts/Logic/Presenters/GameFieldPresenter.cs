using Assets.Scripts.Logic.Descriptions;
using Assets.Scripts.Logic.Models;
using Assets.Scripts.Logic.Views;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Logic.Presenters
{
    public class GameFieldPresenter : IPresenter
    {
        [Inject]
        private readonly GameFieldModel _gameFieldModel;
        [Inject]
        private readonly TileClickInputModel _tileClickInputModel;
        [Inject]
        private readonly GameFieldDescription _gameFieldDescription;
        [Inject]
        private readonly TileColorsDescription _tileColorsDescription;
        [Inject]
        private readonly GameFieldView _gameFieldView;
        [Inject]
        private readonly TileView _tilePrefab;

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

            for (int i = 0; i < _gameFieldModel.Width; i++)
            {
                for (int j = 0; j < _gameFieldModel.Height; j++)
                {
                    var view = Object.Instantiate(_tilePrefab, _gameFieldView.transform);

                    var presenter = new TilePresenter(_gameFieldModel[i, j], _tileClickInputModel, _gameFieldDescription, _tileColorsDescription, view);
                    _presenters[i, j] = presenter;
                    presenter.Enable();
                }
            }
        }
    }
}