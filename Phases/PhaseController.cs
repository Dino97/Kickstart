using UnityEngine;
using UnityEngine.Events;

namespace Kickstart
{
    public class PhaseController : MonoBehaviour
    {
        public Phase CurrentPhase { get; private set; }

        public UnityEvent OnPhaseChanged;

        private Phase[] _phases;
        private int _currentPhaseId;




        private void Start()
        {
            _phases = GetComponentsInChildren<Phase>();

            if (_phases.Length > 0)
            {
                _currentPhaseId = -1;
                StartNextPhase();
            }
        }

        private void Update()
        {
            if (CurrentPhase != null)
            {
                CurrentPhase.OnUpdate();

                if (CurrentPhase.IsFinished)
                    StartNextPhase();
            }

#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Space))
            StartNextPhase();
#endif
        }

        public void StartNextPhase()
        {
            CurrentPhase?.OnFinish();

            if (_currentPhaseId < _phases.Length - 1)
            {
                CurrentPhase = _phases[++_currentPhaseId];
                CurrentPhase.OnStart();
            }
            else
            {
                CurrentPhase = null;
            }

            // Dont invoke event on -1 to 0 phase transition
            if (_currentPhaseId > 0)
                OnPhaseChanged?.Invoke();
        }
    }
}