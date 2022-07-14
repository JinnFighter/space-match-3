using Assets.Scripts.Common;
using Assets.Scripts.Logic.Content;
using Assets.Scripts.Logic.Models;
using Assets.Scripts.Logic.Views;
using System.Collections.Generic;
using UnityEngine;

public class GameFieldContentController : IController
{
    private readonly GameFieldModel _gameFieldModel;
    private readonly PrefabsContent _prefabsContent;
    private readonly ViewContainer _viewContainer;
    private readonly Dictionary<TileModel, IController> _tileControllers = new();

    private GameFieldView _view;

    public GameFieldContentController(GameFieldModel gameFieldModel, PrefabsContent prefabsContent, ViewContainer viewContainer)
    {
        _gameFieldModel = gameFieldModel;
        _prefabsContent = prefabsContent;
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

        if(_view != null)
        {
            Object.Destroy(_view.gameObject);
        }
    }

    public void Enable()
    {
        _view = Object.Instantiate(_prefabsContent.GameFieldView, _viewContainer.GameplayCanvas.transform);

        for(var i = 0; i < _gameFieldModel.Width; i++)
        {
            for (var j = 0; j < _gameFieldModel.Height; j++)
            {
                var controller = new TileContentController(_gameFieldModel.Tiles[i, j], _prefabsContent.TileView, _view);
                _tileControllers.Add(_gameFieldModel.Tiles[i, j], controller);
                controller.Enable();
            }
        }
    }
}
