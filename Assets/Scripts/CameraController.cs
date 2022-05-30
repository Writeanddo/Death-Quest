using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private float Horizontal, Vertical;


    [SerializeField] float HorizontalSens, VerticalSens;
    [SerializeField] Camera Camera;
    [SerializeField] GameObject Player;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal += Input.GetAxis("Mouse X") * HorizontalSens * .002f;
        Vertical -= Input.GetAxis("Mouse Y") * VerticalSens * .002f;

        Vertical = Mathf.Clamp(Vertical, -90f, 90f);

        Player.transform.eulerAngles = new Vector3(0f, Horizontal, 0f);
        transform.eulerAngles = new Vector3(Vertical, Horizontal, 0f);


    }
}
