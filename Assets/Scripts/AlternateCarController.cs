using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternateCarController : MonoBehaviour
{
    private Rigidbody myBody;

    public GameObject frontLeftMesh;
    public GameObject frontRightMesh;

    public WheelCollider frontLeftCollider;
    public WheelCollider frontRightCollider;
    public ParticleSystem RLWParticleSystem;
    public ParticleSystem RRWParticleSystem;

    string horizontalAxis;
    float horizontal;


    private Vector3 v;
    private Vector3 point;
    private bool isRotating;

    private float steeringAxis;

    private const float MAX_STEERING_ANGLE = 40f;
    private const float STEERING_SPEED = 0.5f;

    void Start()
    {
        myBody = GetComponent<Rigidbody>();
        horizontalAxis = gameObject.tag == "PolicePlayer" ? "PoliceHorizontal" : "Horizontal";
        point = new Vector3(0, 0, 0);
        isRotating = false;
    }

    void Update()
    {
        myBody.transform.Translate(Vector3.forward * 50f * Time.deltaTime);

        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0f)
        {
            if (!isRotating)
            {
                point = myBody.transform.position + new Vector3(horizontal * 25f * Time.deltaTime, 0, 0);
                isRotating = true;
                float rotationSpeed = 1000f;
                float rotation = horizontal * rotationSpeed;
                var q = myBody.transform.rotation;
                myBody.transform.RotateAround(point, new Vector3(0, 1, 0), rotation * Time.deltaTime);
                myBody.transform.rotation = q;
            }

            if (steeringAxis > 0.9f || steeringAxis < -0.9f)
            {
                try
                {
                    RLWParticleSystem.Play();
                    RRWParticleSystem.Play();
                }
                catch (Exception ex)
                {
                    Debug.LogWarning(ex);
                }
            }

            myBody.transform.Rotate(Vector3.up, 200f * Time.deltaTime * horizontal);
        }
        else
        {
            RLWParticleSystem.Stop();
            RRWParticleSystem.Stop();
        }

        if (horizontal < 0f)
        {
            TurnLeft();
        }
        if (horizontal > 0f)
        {
            TurnRight();
        }

        if (!(horizontal < 0f) && !(horizontal > 0f) && steeringAxis != 0f)
        {
            ResetSteeringAngle();
        }

        AnimateWheelMeshes();
    }

    public void TurnLeft()
    {
        steeringAxis = steeringAxis - (Time.deltaTime * 10f * STEERING_SPEED);
        if (steeringAxis < -1f)
        {
            steeringAxis = -1f;
        }
        var steeringAngle = steeringAxis * 35;
        frontLeftCollider.steerAngle = Mathf.Lerp(frontLeftCollider.steerAngle, steeringAngle, STEERING_SPEED);
        frontRightCollider.steerAngle = Mathf.Lerp(frontRightCollider.steerAngle, steeringAngle, STEERING_SPEED);
    }

    public void TurnRight()
    {
        steeringAxis = steeringAxis + (Time.deltaTime * 10f * STEERING_SPEED);
        if (steeringAxis > 1f)
        {
            steeringAxis = 1f;
        }
        var steeringAngle = steeringAxis * MAX_STEERING_ANGLE;
        frontLeftCollider.steerAngle = Mathf.Lerp(frontLeftCollider.steerAngle, steeringAngle, STEERING_SPEED);
        frontRightCollider.steerAngle = Mathf.Lerp(frontRightCollider.steerAngle, steeringAngle, STEERING_SPEED);
    }

    public void ResetSteeringAngle()
    {
        if (steeringAxis < 0f)
        {
            steeringAxis = steeringAxis + (Time.deltaTime * 40f * STEERING_SPEED);
        }
        else if (steeringAxis > 0f)
        {
            steeringAxis = steeringAxis - (Time.deltaTime * 40f * STEERING_SPEED);
        }
        if (Mathf.Abs(frontLeftCollider.steerAngle) < 1f)
        {
            steeringAxis = 0f;
        }
        Debug.Log(steeringAxis + " to reset");
        var steeringAngle = steeringAxis * MAX_STEERING_ANGLE;
        frontLeftCollider.steerAngle = Mathf.Lerp(frontLeftCollider.steerAngle, steeringAngle, STEERING_SPEED);
        frontRightCollider.steerAngle = Mathf.Lerp(frontRightCollider.steerAngle, steeringAngle, STEERING_SPEED);
    }

    void AnimateWheelMeshes()
    {
        try
        {
            Quaternion FLWRotation;
            Vector3 FLWPosition;
            frontLeftCollider.GetWorldPose(out FLWPosition, out FLWRotation);
            frontLeftMesh.transform.position = FLWPosition;
            frontLeftMesh.transform.rotation = FLWRotation;

            Quaternion FRWRotation;
            Vector3 FRWPosition;
            frontRightCollider.GetWorldPose(out FRWPosition, out FRWRotation);
            frontRightMesh.transform.position = FRWPosition;
            frontRightMesh.transform.rotation = FRWRotation;
        }
        catch (Exception ex)
        {
            Debug.LogWarning(ex);
        }
    }
}
