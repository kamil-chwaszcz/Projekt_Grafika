using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float power;
    public float turningAngle;
    public WheelCollider frontLeft;
    public WheelCollider frontRight;
    public WheelCollider backLeft;
    public WheelCollider backRight;
    public Transform mass;
    public Transform frontLeftObject;
    public Transform frontRightObject;
    public Transform backLeftObject;
    public Transform backRightObject;
    public float velocity;
    public Rigidbody rigidbody;
    public float brake;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.centerOfMass = mass.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        frontLeft.motorTorque = power * Input.GetAxis("Vertical");
        frontRight.motorTorque = power * Input.GetAxis("Vertical");
        backLeft.motorTorque = power * Input.GetAxis("Vertical");
        backRight.motorTorque = power * Input.GetAxis("Vertical");

        frontLeft.steerAngle = turningAngle * Input.GetAxis("Horizontal");
        frontRight.steerAngle = turningAngle * Input.GetAxis("Horizontal");

        velocity = Vector3.Dot(rigidbody.velocity, transform.forward);

        if (Input.GetKey(KeyCode.Mouse1))
        {
            frontLeft.brakeTorque = brake;
            frontRight.brakeTorque = brake;
            backLeft.brakeTorque = brake;
            backRight.brakeTorque = brake;
        }
        else
        {
            frontLeft.brakeTorque = 0;
            frontRight.brakeTorque = 0;
            backLeft.brakeTorque = 0;
            backRight.brakeTorque = 0;
        }


        WheelsUpdate();
    }

    void WheelsUpdate()
    {
        Quaternion frontLeftWheelRotation;
        Vector3 frontLeftWheelPosition;

        Quaternion frontRightWheelRotation;
        Vector3 frontRightWheelPosition;

        Quaternion backLeftWheelRotation;
        Vector3 backLeftWheelPosition;

        Quaternion backRightWheelRotation;
        Vector3 backRightWheelPosition;

        frontLeft.GetWorldPose(out frontLeftWheelPosition, out frontLeftWheelRotation);
        frontRight.GetWorldPose(out frontRightWheelPosition, out frontRightWheelRotation);
        backLeft.GetWorldPose(out backLeftWheelPosition, out backLeftWheelRotation);
        backRight.GetWorldPose(out backRightWheelPosition, out backRightWheelRotation);

        frontLeftObject.position = frontLeftWheelPosition;
        frontLeftObject.rotation = frontLeftWheelRotation;

        frontRightObject.position = frontRightWheelPosition;
        frontRightObject.rotation = frontRightWheelRotation;

        backLeftObject.position = backLeftWheelPosition;
        backLeftObject.rotation = backLeftWheelRotation;

        backRightObject.position = backRightWheelPosition;
        backRightObject.rotation = backRightWheelRotation;

    }
}
