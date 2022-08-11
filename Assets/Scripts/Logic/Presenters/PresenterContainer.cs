using System.Collections;
using System.Collections.Generic;
using Zenject;

namespace Assets.Scripts.Logic.Presenters
{
    public class PresenterContainer : IEnumerable<IPresenter>
    {
        [Inject]
        private readonly ScorePresenter _scorePresenter;

        public IEnumerator<IPresenter> GetEnumerator()
        {
            yield return _scorePresenter;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}