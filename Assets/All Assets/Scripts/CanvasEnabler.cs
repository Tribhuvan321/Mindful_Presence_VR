using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasEnabler : MonoBehaviour
{

    public Canvas canvas;
    public GameObject leftController;
    public int minAngle;
    public int maxAngle;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (leftController.transform.rotation.eulerAngles.z > minAngle && leftController.transform.rotation.eulerAngles.z < maxAngle)
        {
            canvas.gameObject.SetActive(true);
        }
        else
        {
            canvas.gameObject.SetActive(false);
        }
    }
}
