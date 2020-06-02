using UnityEngine;
using UnityEngine.Events;

namespace Kickstart
{
	public abstract class Phase : MonoBehaviour
	{
		public UnityEvent OnPhaseStarted;
		public UnityEvent OnPhaseFinished;

		private float _progress;

		#region Properties
		public float Progress
		{
			get { return _progress; }
			protected set { _progress = Mathf.Clamp01(value); }
		}

		public virtual bool IsFinished { get => Progress == 1.0f; }
		#endregion Properties



		public virtual void OnUpdate() { }

		public virtual void OnStart()
		{
			if (OnPhaseStarted != null)
				OnPhaseStarted.Invoke();

			Debug.Log("<color=red>" + GetType().ToString() + "</color> started.");
		}

		public virtual void OnFinish()
		{
			if (OnPhaseFinished != null)
				OnPhaseFinished.Invoke();

			Debug.Log("<color=red>" + GetType().ToString() + "</color> finished.");
		}
	}
}