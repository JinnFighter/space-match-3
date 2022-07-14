using System.Collections.Generic;

namespace Assets.Scripts.Common
{
    public class ControllerContainer
    {
        private readonly List<IController> _controllers = new();

        public void Add(IController controller)
        {
            if(!_controllers.Contains(controller))
            {
                _controllers.Add(controller);
            }
        }

        public void Enable()
        {
            foreach(var controller in _controllers)
            {
                controller.Enable();
            }
        }

        public void Disable()
        {
            foreach (var controller in _controllers)
            {
                controller.Disable();
            }
        }

        public void Clear()
        {
            _controllers.Clear();
        }
    }
}