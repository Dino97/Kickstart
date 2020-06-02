/// Author: Aleksandar Ristic

using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    [SerializeField] float AppliedForce;
    [SerializeField] ForceMode ForceMode;

    private Transform target;
    private List<Rigidbody> _rigidbodies = new List<Rigidbody>(4);



    // Start is called before the first frame update
    private void Start()
    {
        target = transform.GetChild(0);
    }

    private void Update()
    {
        if (_rigidbodies.Count > 0)
        {
            for (int i = 0; i < _rigidbodies.Count; i++)
            {
                if (_rigidbodies[i] != null)
                {
                    Vector3 diff = (target.position - _rigidbodies[i].transform.position);
                    _rigidbodies[i].AddForce(diff * AppliedForce, ForceMode);
                }
            }
        }
    }

    public void Add(Rigidbody rb)
    {
        if (_rigidbodies.Contains(rb) == false)
        {
            rb.useGravity = false;
            rb.drag = 15;
            _rigidbodies.Add(rb);
        }
    }

    public void Remove(Rigidbody rb)
    {
        if (_rigidbodies.Contains(rb) == true)
        {
            rb.useGravity = true;
            rb.drag = 0;
            _rigidbodies.Remove(rb);
        }
    }
}