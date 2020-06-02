using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class TriggerAction : MonoBehaviour
{
    [SerializeField] UnityEvent OnAreaEnter;
    [SerializeField] UnityEvent OnAreaExit;



#if UNITY_EDITOR
    private void Start()
    {
        Debug.Assert(GetComponent<Collider>().isTrigger, "TriggerAction " + name + " is not set to trigger type.");
    }
#endif

    private void OnTriggerEnter(Collider other)
    {
        OnAreaEnter.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        OnAreaExit.Invoke();
    }
}