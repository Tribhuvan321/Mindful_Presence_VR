using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class BookInteractionController : MonoBehaviour
{
    public string targetObjectName = "BookModel";
    public Animator animator;
    public string triggerName = "BookLiftUp";
    public float raycastDistance = 10f;
    public InputActionProperty select;
    public GameObject canvas;
    public GameObject keyboard;

    public Transform vrPointer;

    void Update()
    {
        PerformRaycast();
    }

    void PerformRaycast()
    {
        Ray ray = new Ray(vrPointer.position, vrPointer.forward);
        RaycastHit hit;

        if (select.action.WasPressedThisFrame())
        {
            Debug.Log("select pressed");
            if (Physics.Raycast(ray, out hit, raycastDistance))
            {
                Debug.Log("Raycasted");
                if (hit.collider.gameObject.name == targetObjectName)
                {
                    Debug.Log("object detected");
                    if (animator != null)
                    {
                        animator.SetTrigger(triggerName);
                        //canvas.SetActive(true);
                        keyboard.SetActive(true);
                    }
                    else
                    {
                        Debug.LogWarning("Animator is not assigned!");
                    }
                }
            }
        }
    }
}

