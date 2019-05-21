using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicWheelChair : MonoBehaviour {

    public WheelCollider leftWheel;
    public WheelCollider rightWheel;

    [SerializeField]
    private Transform leftWheelTransform;
    [SerializeField]
    private Transform rightWheelTransform;

    public float MotorTorque;
    public float BrakeTorque;

    [SerializeField]
    private Text wheelsTorqueText;

    PlayerInteraction pl;

    // Use this for initialization
    void Start () {
        pl = GetComponent<PlayerInteraction>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float v = Input.GetAxisRaw("Vertical") * MotorTorque;

        Quaternion rot;
        Vector3 pos;

        if (v != 0)
        {
            leftWheel.motorTorque = rightWheel.motorTorque = 0;
            leftWheel.motorTorque = rightWheel.motorTorque = v;
        }
        else
        {
            if (Input.GetKey(KeyCode.M) && Input.GetKey(KeyCode.Z))
            {
                leftWheel.motorTorque = rightWheel.motorTorque = 0;
                leftWheel.motorTorque = rightWheel.motorTorque = MotorTorque;
            }
            else if (Input.GetKey(KeyCode.X) && Input.GetKey(KeyCode.N))
            {
                leftWheel.motorTorque = rightWheel.motorTorque = -MotorTorque;
            }
            else if(Input.GetKey(KeyCode.M))
            {
                rightWheel.motorTorque = MotorTorque/2;
            }
            else if (Input.GetKey(KeyCode.N))
            {
                rightWheel.motorTorque = -MotorTorque/2;
            }
            else if (Input.GetKey(KeyCode.Z))
            {
                leftWheel.motorTorque = MotorTorque/2;
            }
            else if (Input.GetKey(KeyCode.X))
            {
                leftWheel.motorTorque = -MotorTorque/2;
            }
            else if (Input.GetKey(KeyCode.Space))
            {
                leftWheel.brakeTorque = rightWheel.brakeTorque = BrakeTorque;
            }
            else
            {
                leftWheel.brakeTorque = rightWheel.brakeTorque = 0;
                leftWheel.motorTorque = rightWheel.motorTorque = 0;
            }
            
        }

        leftWheel.GetWorldPose(out pos,out rot);
        leftWheelTransform.rotation=rot;
        rightWheel.GetWorldPose(out pos, out rot);
        rightWheelTransform.rotation = rot;
        updateText();
    }

    private void updateText()
    {
        wheelsTorqueText.text = "Left Wheel: " + leftWheel.motorTorque.ToString() + "\nRight Wheel: " + rightWheel.motorTorque.ToString()+ "\nItems: " + pl.CountItems.ToString();
    }
}
