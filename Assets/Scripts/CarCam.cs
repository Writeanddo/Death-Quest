using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCam : MonoBehaviour
{

    private float Horizontal, Vertical;

    [SerializeField] float HorizontalSens, VerticalSens;
    [SerializeField] Transform lookat;


    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Horizontal += Input.GetAxis("Mouse X") * HorizontalSens * .002f;
        Vertical -= Input.GetAxis("Mouse Y") * VerticalSens * .002f;

        Vertical = Mathf.Clamp(Vertical, -90f, 90f);

        lookat.eulerAngles = new Vector3(Vertical, Horizontal, 0f);


    }
}
