using Assets.Scripts.Logic.Models;
using VContainer;

namespace Assets.Scripts.Logic.Presenters
{
    public class TurnCountPresenter : IPresenter
    {
        [Inject]
        private readonly TurnCountModel _turnCountModel;
        [Inject]
        private readonly TurnCountView _turnCountView;

        public void Disable()
        {
            _turnCountModel.TurnCountChanged -= OnTurnCountChanged;
        }

        public void Enable()
        {
            _turnCountModel.TurnCountChanged += OnTurnCountChanged;
            _turnCountView.SetTurnCount(_turnCountModel.TurnCount);
        }

        private void OnTurnCountChanged(int turnCount)
        {
            _turnCountView.SetTurnCount(turnCount);
        }
    }
}