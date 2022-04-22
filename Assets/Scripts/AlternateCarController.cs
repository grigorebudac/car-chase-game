using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternateCarController : MonoBehaviour
{
    private Rigidbody myBody;
    private float _timer = 0;
    private float _angle = 0;
    public float _speed = 0.02f;
    public float radius = 2;
    private Vector3 rotationAngles;
    private float rotationSpeed;
    private Vector3 center;


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

    float steeringAxis;

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

            try
            {
                RLWParticleSystem.Play();
                RRWParticleSystem.Play();

            }
            catch (Exception ex)
            {
                Debug.LogWarning(ex);
            }

            myBody.transform.Rotate(Vector3.up, 200f * Time.deltaTime * horizontal);
        }
        else
        {
            isRotating = false;
            RRWParticleSystem.Stop();
            RLWParticleSystem.Stop();
        }

        if (horizontal < 0f)
        {
            TurnLeft();
        }
        if (horizontal > 0f)
        {
            TurnRight();
        }

        AnimateWheelMeshes();
    }

    public void TurnLeft()
    {
        steeringAxis = steeringAxis - (Time.deltaTime * 10f * 0.5f);
        if (steeringAxis < -1f)
        {
            steeringAxis = -1f;
        }
        var steeringAngle = steeringAxis * 35;
        frontLeftCollider.steerAngle = Mathf.Lerp(frontLeftCollider.steerAngle, steeringAngle, 0.5f);
        frontRightCollider.steerAngle = Mathf.Lerp(frontRightCollider.steerAngle, steeringAngle, 0.5f);
    }

    //The following method turns the front car wheels to the right. The speed of this movement will depend on the steeringSpeed variable.
    public void TurnRight()
    {
        steeringAxis = steeringAxis + (Time.deltaTime * 10f * 0.5f);
        if (steeringAxis > 1f)
        {
            steeringAxis = 1f;
        }
        var steeringAngle = steeringAxis * 35;
        frontLeftCollider.steerAngle = Mathf.Lerp(frontLeftCollider.steerAngle, steeringAngle, 0.5f);
        frontRightCollider.steerAngle = Mathf.Lerp(frontRightCollider.steerAngle, steeringAngle, 0.5f);
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
