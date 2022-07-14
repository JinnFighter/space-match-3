using Assets.Scripts.Common;
using Assets.Scripts.Logic.Models;
using Assets.Scripts.Logic.Views;
using System.Collections.Generic;
using UnityEngine;

public class GameFieldContentController : IController
{
    private readonly GameFieldModel _gameFieldModel;
    private readonly GameFieldView _content;
    private readonly ViewContainer _viewContainer;
    private readonly Dictionary<TileModel, IController> _tileControllers = new();

    private GameFieldView _view;

    public GameFieldContentController(GameFieldModel gameFieldModel, GameFieldView content, ViewContainer viewContainer)
    {
        _gameFieldModel = gameFieldModel;
        _content = content;
        _viewContainer = viewContainer;
    }

    public void Disable()
    {
        foreach (var model in _gameFieldModel.Tiles)
        {
            if(_tileControllers.TryGetValue(model, out var controller))
            {
                controller.Disable();
            } 
        }

        _tileControllers.Clear();

        Object.Destroy(_view.gameObject);
    }

    public void Enable()
    {
        _view = Object.Instantiate(_content, _viewContainer.GameplayCanvas.transform);

        for(var i = 0; i < _gameFieldModel.Width; i++)
        {
            for (var j = 0; j < _gameFieldModel.Height; j++)
            {
                var controller = new CompositeController(new List<IController>
                {

                });
                _tileControllers.Add(_gameFieldModel.Tiles[i, j], controller);
                controller.Enable();
            }
        }
    }
}
