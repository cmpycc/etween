using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace cmpy.Tween
{
    public abstract class Tween<T> : ITween
    {
        public object owner;

        public readonly Func<T> getter;
        public readonly Action<T> setter;
        public T initialValue;
        public T endValue;
        public float duration;
        public float delay;
        public bool shake = false;
        public bool inSequence = false;

        private bool initialValueSet = false;

        public EaseType easeType = EaseType.Out;
        public Ease ease = new ExpoEase();

        //public bool finished { get; private set; } = false;
        public bool Finished => currentTime >= duration + delay;
        private float currentTime = 0.0f;

        protected Tween(object owner, Func<T> getter, Action<T> setter, T endValue, float duration)
        {
            this.owner = owner;
            this.getter = getter;
            this.setter = setter;
            this.endValue = endValue;
            this.duration = duration;
        }

        // Interpolation should be unclamped in order to support tweens like elastic.
        protected abstract T Interpolate(float time);

        public void Update(float delta)
        {
            currentTime += delta;
            float time = Mathf.Min(duration, Mathf.Max(currentTime - delay, 0.0f)) / duration;

            /*setter(Interpolate(easeType switch
            {
                EaseType.In => ease.ComputeIn(time),
                EaseType.Out => ease.ComputeOut(time),
                EaseType.InOut => ease.ComputeInOut(time),
                _ => throw new NotImplementedException(),
            }));*/

            if (!initialValueSet)
            {
                initialValue = getter();
                initialValueSet = true;
            }

            float easedTime = ease.Compute(easeType, time);
            setter(Interpolate(
                shake ?
                Random.Range(-1.0f, 1.0f) * (1.0f - easedTime)
                : easedTime));

            if (Finished)
            {
                Debug.Log("finished");
                setter(shake ? initialValue : endValue);
            }
        }

        public IEnumerator Await()
        {
            yield return new WaitUntil(() => Finished);
        }

        public Tween<T> From(T initialValue)
        {
            this.initialValue = initialValue;
            initialValueSet = true;
            return this;
        }

        public Tween<T> Delay(float delay)
        {
            this.delay = delay;
            return this;
        }

        public Tween<T> Ease(Ease ease)
        {
            this.ease = ease;
            return this;
        }

        public Tween<T> Ease(EaseType easeType)
        {
            this.easeType = easeType;
            return this;
        }

        public Tween<T> Ease(Ease ease, EaseType easeType)
        {
            this.ease = ease;
            this.easeType = easeType;
            return this;
        }

        public Tween<T> Shake(bool shake = true)
        {
            this.shake = shake;
            return this;
        }
    }
}