using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StoolInteraction : MonoBehaviour
{
    public Transform vrPointer;
    public Transform xrOrigin;
    public GameObject Move;
    public Outline bookOutlineScript;
    public Outline sphereOutlineScript;
    public InputActionProperty activate;
    public float raycastDistance = 20f;

    void Update()
    {
        PerformRaycast();
    }

    void PerformRaycast()
    {
        Ray ray = new Ray(vrPointer.position, vrPointer.forward);
        RaycastHit hit;

        if (activate.action.WasPressedThisFrame())
        {
            if (Physics.Raycast(ray, out hit, raycastDistance))
            {
                Debug.Log($"Hit object tag: {hit.collider.tag}");

                // Check if the object has the "Stool" tag
                if (hit.collider.CompareTag("Stool"))
                {
                    Debug.Log("Condition satisfied: Target object with 'Stool' tag detected.");
                    xrOrigin.position = new Vector3(33.6900024f, 0.537543178f, 12.0823269f);
                    Move.SetActive(false);
                    bookOutlineScript.enabled = true;
                    sphereOutlineScript.enabled = true;
                }
            }
        }
    }
}
