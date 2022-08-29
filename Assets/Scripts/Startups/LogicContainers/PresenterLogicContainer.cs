using Assets.Scripts.Logic.Presenters;
using VContainer;

namespace Startups.LogicContainers
{
    public class PresenterLogicContainer : ILogicContainer
    {
        [Inject] private readonly PresenterContainer _presenterContainer;
        
        public void Init()
        {
            foreach(var presenter in _presenterContainer)
            {
                presenter.Enable();
            }
        }

        public void Destroy()
        {
            foreach (var presenter in _presenterContainer)
            {
                presenter.Disable();
            }
        }
    }
}
