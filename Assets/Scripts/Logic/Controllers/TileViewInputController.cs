using Assets.Scripts.Common;
using Assets.Scripts.Logic.Models;
using Assets.Scripts.Logic.Views;
using UnityEngine;

namespace Assets.Scripts.Logic.Controllers
{
    public class TileViewInputController : IController
    {
        private readonly TileModel _tileModel;
        private readonly TileView _view;

        public TileViewInputController(TileModel tileModel, TileView view)
        {
            _tileModel = tileModel;
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
            Debug.Log($"Clicked at { _tileModel.Position }");
        }
    }
}