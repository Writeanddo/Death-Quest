using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatecanvas : MonoBehaviour
{
    public Transform Cam;

    private void Start()
    {
        Cam = PlayerMovement.instance.cam.transform;
    }
    void LateUpdate()
    {
        transform.LookAt(transform.position + Cam.transform.forward);
    }
}
