using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class DrawBounds : MonoBehaviour
{
    public bool includeChildren;
    public bool inViewSpace;



    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;

        if (!includeChildren)
        {
            Bounds bounds = GetComponent<MeshRenderer>().bounds;
            Gizmos.DrawWireCube(bounds.center, bounds.size);
        }
        else
        {
            Bounds bounds = CalculateBounds(gameObject);
            Gizmos.DrawWireCube(bounds.center, CalculateBounds(gameObject).size);
        }
    }

    private Bounds CalculateBounds(GameObject go)
    {
        MeshRenderer[] meshRenderers = go.GetComponentsInChildren<MeshRenderer>(false);

        Bounds bounds = meshRenderers[0].bounds;

        for (int i = 1; i < meshRenderers.Length; i++)
            bounds.Encapsulate(meshRenderers[i].bounds);

        return bounds;
    }
}
