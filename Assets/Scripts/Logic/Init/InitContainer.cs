using Assets.Scripts.Logic;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.Init
{
    public class InitContainer : IEnumerable<IInit>
    {
        public IEnumerator<IInit> GetEnumerator()
        {
            yield return new GameFieldInit();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}