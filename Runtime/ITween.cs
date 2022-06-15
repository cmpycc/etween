using System;
using System.Collections;

namespace cmpy.Tween
{
    /// <summary>
    /// The bare minimum Tween type. Only TweenEngine should reference this.
    /// </summary>
    /// <seealso cref="Tween{T}"/>
    public interface ITween
    {
        public bool Finished { get; }
        internal bool ShouldUseUnscaledUpdate { get; }
        public void Update(float delta);
        public IEnumerator Await();
    }
}