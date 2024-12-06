using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BreathExerciseModeEnabler : MonoBehaviour
{
    public GameObject canvas;
    public Transform vrPointer;

    public MeditationTextController mtcScript;
    public BreathingCompanionController bccScript;
    public Outline outlineScript;

    public InputActionProperty select;

    public float raycastDistance = 10f;
    public string targetObjectName = "Sphere";

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
            if (Physics.Raycast(ray, out hit, raycastDistance))
            {
                if (hit.collider.gameObject.name == targetObjectName)
                {
                    outlineScript.enabled = false;
                    canvas.SetActive(true);
                    mtcScript.enabled = true;
                    mtcScript.Initialize();
                    bccScript.enabled = true;
                }
            }
        }
    }
}
