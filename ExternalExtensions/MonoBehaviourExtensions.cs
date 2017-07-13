using System;
using System.Collections;
using UnityEngine;

namespace DTEasings {
	public static class MonoBehaviourExtensions {
		// PRAGMA MARK - Static
		public static Coroutine DoEaseFor(this MonoBehaviour m, float duration, EaseType easeType, Action<float> lerpCallback, Action finishedCallback = null) {
			return m.DoLerpFor(duration, (p) => lerpCallback.Invoke(Easings.Interpolate(p, easeType)), finishedCallback);
		}

		private static Coroutine DoLerpFor(this MonoBehaviour m, float duration, Action<float> lerpCallback, Action finishedCallback = null) {
			return m.StartCoroutine(EasingCoroutines.DoLerpCoroutine(duration, lerpCallback, finishedCallback));
		}

		public static Coroutine DoSpringFor(this MonoBehaviour m, float approximateDuration, float dampingRatio, Action<float> lerpCallback, Action finishedCallback = null) {
			return m.StartCoroutine(EasingCoroutines.DoSpringForCoroutine(approximateDuration, dampingRatio, lerpCallback, finishedCallback));
		}
	}
}