using Assets.Scripts.Logic.Models;
using VContainer;

namespace Assets.Scripts.Logic.Presenters
{
    public class TurnCountPresenter : IPresenter
    {
        private readonly TurnCountModel _turnCountModel;
        private readonly TurnCountView _turnCountView;

        [Inject]
        public TurnCountPresenter(TurnCountModel turnCountModel, TurnCountView turnCountView)
        {
            _turnCountModel = turnCountModel;
            _turnCountView = turnCountView;
        }

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