using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";

    private const string VERTICAL = "Vertical";

    private float horizontalInput;
    private float verticalInput;
    private float currentSteerAngle;
    private float BreakForce;
    private bool IsBreaking;

    [SerializeField] private float motorForce;
    [SerializeField] private float currentBreakForce;
    [SerializeField] private float MaxSteerAngle;

    [SerializeField] private WheelCollider FrontLeftCollider;
    [SerializeField] private WheelCollider FrontRightCollider;
    [SerializeField] private WheelCollider RearLeftCollider;
    [SerializeField] private WheelCollider RearRightCollider;

    [SerializeField] private Transform FrontLeftWheel;
    [SerializeField] private Transform FrontRightWheel;
    [SerializeField] private Transform RearLeftWheel;
    [SerializeField] private Transform RearRightWheel;

    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);
    }

    private void HandleMotor(){
        FrontLeftCollider.motorTorque = verticalInput * motorForce *1000f;
        FrontRightCollider.motorTorque = verticalInput * motorForce * 1000f;
        currentBreakForce = IsBreaking ? BreakForce : 0f;
        applyBreaking();
    }

    private void applyBreaking()
    {

        FrontRightCollider.brakeTorque = currentBreakForce;
        FrontLeftCollider.brakeTorque = currentBreakForce;
        RearRightCollider.brakeTorque = currentBreakForce;
        RearLeftCollider.brakeTorque = currentBreakForce;
    }

    private void HandleSteering()
    {
        currentSteerAngle = MaxSteerAngle * horizontalInput;
        FrontLeftCollider.steerAngle = currentSteerAngle;
        FrontRightCollider.steerAngle = currentSteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(FrontLeftCollider, FrontLeftWheel);
        UpdateSingleWheel(FrontRightCollider, FrontRightWheel);
        UpdateSingleWheel(RearRightCollider, RearRightWheel);
        UpdateSingleWheel(RearLeftCollider, RearLeftWheel);
    }

    private void UpdateSingleWheel(WheelCollider WheeleCollider, Transform WheeleTransform)
    {
        Vector3 position;
        Quaternion rotation;
        WheeleCollider.GetWorldPose(out position, out rotation);
        WheeleTransform.position = position;
        WheeleTransform.rotation = rotation;
    }

}