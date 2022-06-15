using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

using Random = UnityEngine.Random;

namespace cmpy.Tween
{
    /// <summary>
    /// The main Tween type. 
    /// </summary>
    /// <typeparam name="T">The type being tweened.</typeparam>
    public abstract class Tween<T> : ITween
    {
        /// <summary>
        /// The object that owns the property being tweened.
        /// </summary>
        public readonly object owner;

        /// <summary>
        /// Callback that returns the current value of the property.
        /// </summary>
        public readonly Func<T> getter;
        /// <summary>
        /// Callback that update the current value of the property.
        /// </summary>
        public readonly Action<T> setter;
        public T initialValue;
        public T endValue;
        /// <summary>
        /// How long the tween will take to complete.
        /// </summary>
        public float duration;
        /// <summary>
        /// How long until the tween begins.
        /// </summary>
        public float delay;
        /// <summary>
        /// If true, the tween will shake, using <see cref="endValue"/> as a "radius."
        /// The tween will end on it's <see cref="initialValue"/>.
        /// If false, the tween will act normally.
        /// </summary>
        public bool shake = false;
        /// <summary>
        /// If true, the tween will use unscaled deltaTime.
        /// </summary>
        public bool useUnscaledUpdate = false;
        public bool ShouldUseUnscaledUpdate => useUnscaledUpdate;

        private bool initialValueSet = false;
        private bool finishEarly = false;

        /// <summary>
        /// The direction of easing.
        /// </summary>
        public EaseType easeType = EaseType.Out;
        /// <summary>
        /// The type of ease used.
        /// </summary>
        public Ease ease = new ExpoEase();

        public bool Finished => currentTime >= duration + delay || finishEarly;
        private float currentTime = 0.0f;

        /// <summary>
        /// Fired when the tween finishes uninterupted.
        /// </summary>
        public UnityEvent onComplete = new UnityEvent();
        /// <summary>
        /// Fired when the tween finishes.
        /// </summary>
        public UnityEvent onFinish = new UnityEvent();

        private bool onCompleteInvoked = false, onFinishInvoked = false;

        protected Tween(object owner, Func<T> getter, Action<T> setter, T endValue, float duration)
        {
            this.owner = owner;
            this.getter = getter;
            this.setter = setter;
            this.endValue = endValue;
            this.duration = duration;
        }

        /// <summary>
        /// Interpolates the tweened type.
        /// </summary>
        /// <param name="time">The time of the tween, as a percentage (0.0-1.0).</param>
        /// <returns>Should return an interpolation of the type.</returns>
        /// <remarks>Interpolation should be unclamped in order to support eases like elastic.</remarks>
        protected abstract T Interpolate(float time);

        public void Update(float delta)
        {
            currentTime += delta;
            float time = Mathf.Min(duration, Mathf.Max(currentTime - delay, 0.0f)) / duration;

            if (!initialValueSet)
            {
                initialValue = getter();
                initialValueSet = true;
            }

            float easedTime = ease.Compute(easeType, time);
            // TODO: Shake needs some work lmao
            setter(Interpolate(
                shake ?
                Random.Range(-1.0f, 1.0f) * (1.0f - easedTime)
                : easedTime));

            if (Finished)
            {
                setter(shake ? initialValue : endValue);

                // Fire onFinished
                if (!onFinishInvoked)
                {
                    onFinish.Invoke();
                    onFinishInvoked = true;
                }

                // Fire onComplete
                if (!onCompleteInvoked && !finishEarly)
                {
                    onComplete.Invoke();
                    onCompleteInvoked = true;
                }
            }
        }

        public IEnumerator Await()
        {
            yield return new WaitUntil(() => Finished);
        }

        /// <summary>
        /// Overrides <see cref="initialValue"/>.
        /// </summary>
        /// <param name="initialValue"></param>
        /// <returns></returns>
        public Tween<T> From(T initialValue)
        {
            this.initialValue = initialValue;
            initialValueSet = true;
            return this;
        }

        /// <summary>
        /// Sets <see cref="delay"/>.
        /// </summary>
        /// <param name="delay"></param>
        /// <returns></returns>
        public Tween<T> Delay(float delay)
        {
            this.delay = delay;
            return this;
        }

        /// <summary>
        /// Sets <see cref="ease"/>.
        /// </summary>
        /// <param name="ease"></param>
        /// <returns></returns>
        public Tween<T> Ease(Ease ease)
        {
            this.ease = ease;
            return this;
        }

        /// <summary>
        /// Sets <see cref="easeType"/>.
        /// </summary>
        /// <param name="easeType"></param>
        /// <returns></returns>
        public Tween<T> Ease(EaseType easeType)
        {
            this.easeType = easeType;
            return this;
        }

        /// <summary>
        /// Sets <see cref="ease"/> and <see cref="easeType"/>.
        /// </summary>
        /// <param name="ease"></param>
        /// <param name="easeType"></param>
        /// <returns></returns>
        public Tween<T> Ease(Ease ease, EaseType easeType)
        {
            this.ease = ease;
            this.easeType = easeType;
            return this;
        }

        /// <summary>
        /// Sets <see cref="shake"/>.
        /// </summary>
        /// <param name="shake"></param>
        /// <returns></returns>
        public Tween<T> Shake(bool shake = true)
        {
            this.shake = shake;
            return this;
        }

        /// <summary>
        /// Sets <see cref="useUnscaledUpdate"/>.
        /// </summary>
        /// <param name="useUnscaledUpdate"></param>
        /// <returns></returns>
        public Tween<T> UseUnscaledUpdate(bool useUnscaledUpdate = true)
        {
            this.useUnscaledUpdate = useUnscaledUpdate;
            return this;
        }

        /// <summary>
        /// Adds a listener to <see cref="onComplete"/>.
        /// </summary>
        /// <param name="listener"></param>
        /// <returns></returns>
        public Tween<T> OnComplete(UnityAction listener)
        {
            onFinish.AddListener(listener);
            return this;
        }

        /// <summary>
        /// Adds a listener to <see cref="onFinish"/>.
        /// </summary>
        /// <param name="listener"></param>
        /// <returns></returns>
        public Tween<T> OnFinish(UnityAction listener)
        {
            onFinish.AddListener(listener);
            return this;
        }

        /// <summary>
        /// Finish the tween early.
        /// </summary>
        public void Finish()
        {
            finishEarly = true;
        }
    }
}