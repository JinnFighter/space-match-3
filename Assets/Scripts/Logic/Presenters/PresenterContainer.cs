using System.Collections;
using System.Collections.Generic;
using Zenject;

namespace Assets.Scripts.Logic.Presenters
{
    public class PresenterContainer : IEnumerable<IPresenter>
    {
        [Inject]
        private readonly GameFieldPresenter _gameFieldPresenter;
        [Inject]
        private readonly ScorePresenter _scorePresenter;
        [Inject]
        private readonly TurnCountPresenter _turnCountPresenter;

        public IEnumerator<IPresenter> GetEnumerator()
        {
            yield return _gameFieldPresenter;
            yield return _scorePresenter;
            yield return _turnCountPresenter;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}