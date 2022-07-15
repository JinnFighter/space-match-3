using Assets.Scripts.Common;
using Assets.Scripts.Logic.Models;
using Assets.Scripts.Logic.Views;

public class TileViewSelectionController : IController
{
    private readonly TileModel _tileModel;
    private readonly TileView _tileView;

    public TileViewSelectionController(TileModel tileModel, TileView tileView)
    {
        _tileModel = tileModel;
        _tileView = tileView;
    }

    public void Disable()
    {
        _tileModel.IsSelectedChanged -= OnSelectedChanged;
    }

    public void Enable()
    {
        _tileModel.IsSelectedChanged += OnSelectedChanged;
        if(_tileModel.IsSelected)
        {
            _tileView.Select();
        }
    }

    private void OnSelectedChanged(bool value)
    {
        if(value)
        {
            _tileView.Select();
        }
        else
        {
            _tileView.Deselect();
        }
    }
}
