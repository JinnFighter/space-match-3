using System.Collections.Generic;

namespace Assets.Scripts.Common
{
    public class CompositeController : IController
    {
        private readonly List<IController> _controllers;

        public CompositeController(List<IController> controllers)
        {
            _controllers = controllers;
        }

        public void Disable()
        {
            foreach (var controller in _controllers)
            {
                controller.Disable();
            }
        }

        public void Enable()
        {
            foreach(var controller in _controllers)
            {
                controller.Enable();
            }
        }
    }
}