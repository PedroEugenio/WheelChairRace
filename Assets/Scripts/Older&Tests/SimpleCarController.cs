using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SimpleCarController : MonoBehaviour
{
    public List<AxleInfo> axleInfos; // the information about each individual axle
    public float maxMotorTorque; // maximum torque the motor can apply to wheel
    public float maxSteeringAngle; // maximum steer angle the wheel can have
    public float decelerationForce;
    public float brakeForce;

    public void FixedUpdate()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        //float motorR = maxMotorTorque * Input.GetAxis("Horizontal");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = Mathf.Lerp(axleInfo.leftWheel.steerAngle,steering,Time.deltaTime*4);
                axleInfo.rightWheel.steerAngle = Mathf.Lerp(axleInfo.leftWheel.steerAngle, steering, Time.deltaTime * 4);
            }
            if (axleInfo.motor)
            {
                if (Input.GetKey(KeyCode.M))
                    axleInfo.rightWheel.motorTorque = maxMotorTorque;
                else if (Input.GetKey(KeyCode.Z))
                    axleInfo.leftWheel.motorTorque = maxMotorTorque;
                else if (Input.GetKey(KeyCode.N))
                    axleInfo.rightWheel.motorTorque = -maxMotorTorque;
                else if (Input.GetKey(KeyCode.X))
                    axleInfo.leftWheel.motorTorque = -maxMotorTorque;
                else
                {
                    axleInfo.leftWheel.motorTorque = 0.0f;
                    axleInfo.rightWheel.motorTorque = 0.0f;
                    axleInfo.rightWheel.motorTorque = motor;
                    axleInfo.leftWheel.motorTorque = motor;
                }

                //axleInfo.rightWheel.motorTorque = (Input.GetKey(KeyCode.M)) ? maxMotorTorque : 0.0f;
                //axleInfo.rightWheel.motorTorque = (Input.GetKey(KeyCode.N)) ? -maxMotorTorque : 0.0f;
                //axleInfo.leftWheel.motorTorque = (Input.GetKey(KeyCode.Z)) ? maxMotorTorque : 0.0f;
                //axleInfo.leftWheel.motorTorque = (Input.GetKey(KeyCode.X)) ? -maxMotorTorque : 0.0f;

                axleInfo.leftWheel.brakeTorque = (Input.GetKey(KeyCode.Space)) ? brakeForce : decelerationForce - Mathf.Abs(Input.GetAxis("Vertical") * decelerationForce);
                axleInfo.rightWheel.brakeTorque = (Input.GetKey(KeyCode.Space)) ? brakeForce : decelerationForce - Mathf.Abs(Input.GetAxis("Vertical") * decelerationForce);
                Debug.Log("LeftWheel: " + axleInfo.leftWheel.brakeTorque);
            }
        }
    }
}

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor; // is this wheel attached to motor?
    public bool steering; // does this wheel apply steer angle?
}
