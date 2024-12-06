using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.name);
        if(collision.collider.name == "XR Origin(XR Rig)(1)")
        {
            this.gameObject.GetComponent<BoxCollider>().isTrigger = true;
        }
    }
}
