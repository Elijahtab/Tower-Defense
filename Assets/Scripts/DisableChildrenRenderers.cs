using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableChildrenRenderers : MonoBehaviour
{
    private void Start()
    {
        DisableRenderersRecursive(transform);
    }

    private void DisableRenderersRecursive(Transform parent)
    {
        foreach (Transform child in parent)
        {
            // Disable Renderer component if it exists
            Renderer renderer = child.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.enabled = false;
            }

        }
    }
}