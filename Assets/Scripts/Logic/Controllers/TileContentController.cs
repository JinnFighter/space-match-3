using Assets.Scripts.Common;
using Assets.Scripts.Logic.Models;
using Assets.Scripts.Logic.Views;
using System.Collections.Generic;
using UnityEngine;

public class TileContentController : IController
{
    private readonly TileModel _tileModel;
    private readonly TileView _content;
    private readonly GameFieldView _gameFieldView;

    private IController _controllers;

    private TileView _view;

    public TileContentController(TileModel tileModel, TileView content, GameFieldView gameFieldView)
    {
        _tileModel = tileModel;
        _content = content;
        _gameFieldView = gameFieldView;
    }

    public void Disable()
    {
        _controllers.Disable();
        Object.Destroy(_view);
    }

    public void Enable()
    {
        _view = Object.Instantiate(_content, _gameFieldView.transform);
        _controllers = new CompositeController(new List<IController>
        {

        });
        _controllers.Enable();
    }
}
