using Assets.Scripts.Common;
using Assets.Scripts.Logic.Models;
using Assets.Scripts.Logic.Views;

namespace Assets.Scripts.Logic.Controllers
{
    public class TileViewInputController : IController
    {
        private readonly TileModel _tileModel;
        private readonly SelectedTilesModel _selectedTilesModel;
        private readonly TileView _view;

        public TileViewInputController(TileModel tileModel, SelectedTilesModel selectedTilesModel, TileView view)
        {
            _tileModel = tileModel;
            _selectedTilesModel = selectedTilesModel;
            _view = view;
        }

        public void Disable()
        {
            _view.ClickEvent -= OnClickEvent;
        }

        public void Enable()
        {
            _view.ClickEvent += OnClickEvent;
        }

        private void OnClickEvent()
        {
            _selectedTilesModel.SelectedPosition = _tileModel.Position;
        }
    }
}