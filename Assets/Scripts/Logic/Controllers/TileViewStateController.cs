using Assets.Scripts.Common;
using Assets.Scripts.Logic.Models;
using Assets.Scripts.Logic.Views;

namespace Assets.Scripts.Logic.Controllers
{
    public class TileViewStateController : IController
    {
        private readonly TileModel _model;
        private readonly TileView _view;

        public TileViewStateController(TileModel model, TileView view)
        {
            _model = model;
            _view = view;
        }

        public void Disable()
        {
            _model.StateChanged -= OnStateChanged;
        }

        public void Enable()
        {
            _model.StateChanged += OnStateChanged;
            _view.SetState(_model.State);
        }

        private void OnStateChanged(int value)
        {
            _view.SetState(value);
        }
    }
}