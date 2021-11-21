using System;
using System.Collections;

namespace cmpy.Tween
{
    public interface ITween
    {
        public bool Finished { get; }
        public void Update(float delta);
        public IEnumerator Await();
    }
}