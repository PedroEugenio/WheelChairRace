using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class wheelchairMovement : MonoBehaviour
{
    public List<AxleInfo> axleInfos; // the information about each individual axle
    public float maxMotorTorque; // maximum torque the motor can apply to wheel
    public float maxSteeringAngle; // maximum steer angle the wheel can have
    public float decelerationForce;
    public float brakeTorque;

    public void FixedUpdate()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        for (int i = 0; i < axleInfos.Count; i++)
        {
            if (axleInfos[i].steering)
            {
                Steering(axleInfos[i], steering);
            }
            if (axleInfos[i].motor)
            {
                Acceleration(axleInfos[i], motor);
            }
            if (Input.GetKey(KeyCode.Space))
            {
                Brake(axleInfos[i]);
            }
            //ApplyLocalPositionToVisuals(axleInfos[i]);
        }
    }

    private void Acceleration(AxleInfo axleInfo, float motor)
    {
        if (motor != 0f)
        {
            axleInfo.leftWheel.brakeTorque = 0;
            axleInfo.rightWheel.brakeTorque = 0;
            axleInfo.leftWheel.motorTorque = motor;
            axleInfo.rightWheel.motorTorque = motor;
        }
        else
        {
            Deceleration(axleInfo);
        }
    }
    private void Deceleration(AxleInfo axleInfo)
    {
        axleInfo.leftWheel.brakeTorque = decelerationForce;
        axleInfo.rightWheel.brakeTorque = decelerationForce;
    }
    private void Steering(AxleInfo axleInfo, float steering)
    {
        axleInfo.leftWheel.steerAngle = steering;
        axleInfo.rightWheel.steerAngle = steering;
    }
    private void Brake(AxleInfo axleInfo)
    {
        axleInfo.leftWheel.brakeTorque = brakeTorque;
        axleInfo.rightWheel.brakeTorque = brakeTorque;
    }
}

//[System.Serializable]
//public class AxleInfo
//{
//    public WheelCollider leftWheel;
//    public WheelCollider rightWheel;
//    public bool motor; // is this wheel attached to motor?
//    public bool steering; // does this wheel apply steer angle?
//}
