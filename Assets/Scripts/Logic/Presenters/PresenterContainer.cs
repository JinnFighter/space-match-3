using System.Collections;
using System.Collections.Generic;
using Logic.Presenters;
using VContainer;

namespace Assets.Scripts.Logic.Presenters
{
    public class PresenterContainer : IEnumerable<IPresenter>
    {
        private readonly GameFieldPresenter _gameFieldPresenter;
        private readonly ScorePresenter _scorePresenter;
        private readonly TurnCountPresenter _turnCountPresenter;
        private readonly GameOverPresenter _gameOverPresenter;

        [Inject]
        public PresenterContainer(GameFieldPresenter gameFieldPresenter, ScorePresenter scorePresenter, TurnCountPresenter turnCountPresenter, GameOverPresenter gameOverPresenter)
        {
            _gameFieldPresenter = gameFieldPresenter;
            _scorePresenter = scorePresenter;
            _turnCountPresenter = turnCountPresenter;
            _gameOverPresenter = gameOverPresenter;
        }

        public IEnumerator<IPresenter> GetEnumerator()
        {
            yield return _gameFieldPresenter;
            yield return _scorePresenter;
            yield return _turnCountPresenter;
            yield return _gameOverPresenter;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}