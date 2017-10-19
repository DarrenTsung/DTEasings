using System;
using System.Collections;
using UnityEngine;

namespace DTEasings {
	public static class EasingCoroutines {
		// PRAGMA MARK - Static
		public static IEnumerator DoSpringForCoroutine(float approximateDuration, float dampingRatio, Action<float> lerpCallback, Action finishedCallback) {
			float angularFrequency = 2.0f * Mathf.PI / approximateDuration;

			float currentValue = 0.0f;
			float velocity = 0.0f;
			while (!Mathf.Approximately(currentValue, 1.0f) || velocity > Mathf.Epsilon) {
				currentValue = Springs.StableSpring(currentValue, 1.0f, ref velocity, dampingRatio, angularFrequency);

				lerpCallback.Invoke(currentValue);
				yield return null;
			}

			lerpCallback.Invoke(1.0f);

			if (finishedCallback != null) {
				finishedCallback.Invoke();
			}
		}

		public static IEnumerator DoLerpCoroutine(float duration, Action<float> lerpCallback, Action finishedCallback) {
			for (float time = 0.0f; time <= duration; time += Time.deltaTime) {
				lerpCallback.Invoke(time / duration);
				yield return null;
			}

			lerpCallback.Invoke(1.0f);

			if (finishedCallback != null) {
				finishedCallback.Invoke();
			}
		}

		public static IEnumerator DoEaseCoroutine(float duration, EaseType easeType, Action<float> lerpCallback) {
			for (float time = 0.0f; time <= duration; time += Time.deltaTime) {
				float p = Easings.Interpolate(time / duration, easeType);
				lerpCallback.Invoke(p);
				yield return null;
			}

			lerpCallback.Invoke(1.0f);
		}
	}
}
