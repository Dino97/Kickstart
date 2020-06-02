using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class DelayedAction : MonoBehaviour
{
    public float delay = 1.0f;
    public bool activateOnStart = true;

    public UnityEvent action;



    private void Start()
    {
        if (activateOnStart)
            Activate();
    }

    private IEnumerator Routine()
    {
        yield return new WaitForSeconds(delay);

        action.Invoke();
    }

    public void Activate()
    {
        StartCoroutine(Routine());
    }
}