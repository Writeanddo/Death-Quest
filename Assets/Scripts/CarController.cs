using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] float steerangle;

    [SerializeField] float Horizontal, Vertical;

    public WheelCollider frontleftW, frontrightW;
    public WheelCollider backleftW, backrightW;

    public Transform frontleftT, frontrightT;
    public Transform backleftT, backrightT;

    public float maxsteerangle = 30;
    public float motorforce = 50;

    private void FixedUpdate()
    {
        getinput();
        steer();
        accelerate();
        updatewheelposes();
    }
    private void getinput()
    {
         Horizontal = Input.GetAxis("Horizontal");
         Vertical = Input.GetAxis("Vertical");

    }

    private void steer()
    {
        steerangle = maxsteerangle * Horizontal;
        frontleftW.steerAngle = steerangle;
        frontrightW.steerAngle = steerangle;
    }

    private void accelerate()
    {
        frontleftW.motorTorque = Vertical * motorforce;
        frontrightW.motorTorque = Vertical * motorforce;
    }

    private void updatewheelposes()
    {
        updatewheelpose(frontleftW, frontleftT);
        updatewheelpose(frontrightW, frontrightT);
        updatewheelpose(backleftW, backleftT);
        updatewheelpose(backrightW, backrightT);
    }

    private void updatewheelpose(WheelCollider collider, Transform transform)
    {
        Vector3 pos = transform.position;
        Quaternion quat = transform.rotation;

        collider.GetWorldPose(out pos, out quat);

        transform.position = pos;
        transform.rotation = quat;
    }

}
