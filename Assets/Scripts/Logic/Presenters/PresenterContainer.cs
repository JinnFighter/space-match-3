using System.Collections.Generic;

namespace Assets.Scripts.Logic.Presenters
{
    public class PresenterContainer
    {
        private readonly List<IPresenter> _presenters = new();

        public void Add(IPresenter presenter) => _presenters.Add(presenter);

        public void Disable()
        {
            foreach (var presenter in _presenters)
            {
                presenter.Disable();
            }
        }

        public void Enable()
        {
            foreach(var presenter in _presenters)
            {
                presenter.Enable();
            }
        }

        public void Clear() => _presenters.Clear();
    }
}