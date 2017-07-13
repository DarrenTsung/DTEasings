#if DT_CORE_MODULE
using System;
using System.Collections;
using UnityEngine;

using DTEasings;

namespace DT {
	public partial class CoroutineWrapper {
		// PRAGMA MARK - Static
		public static CoroutineWrapper DoEaseFor(float duration, EaseType easeType, Action<float> lerpCallback, Action finishedCallback = null) {
			return CoroutineWrapper.DoLerpFor(duration, (p) => lerpCallback.Invoke(Easings.Interpolate(p, easeType)), finishedCallback);
		}

		/// <param name="dampingRatio">lower values are less damped and higher values are more damped resulting in less springiness.
		/// should be between 0.01f, 1f to avoid unstable systems.
		public static CoroutineWrapper DoSpringFor(float approximateDuration, float dampingRatio, Action<float> lerpCallback, Action finishedCallback = null) {
			return CoroutineWrapper.StartCoroutine(EasingCoroutines.DoSpringForCoroutine(approximateDuration, dampingRatio, lerpCallback, finishedCallback));
		}
	}
}
#endif