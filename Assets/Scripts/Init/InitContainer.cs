using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.Init
{
    public class InitContainer : IEnumerable<IInit>
    {
        public IEnumerator<IInit> GetEnumerator()
        {
            yield break;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}