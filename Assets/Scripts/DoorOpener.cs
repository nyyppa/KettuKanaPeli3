using UnityEngine;
using System.Collections;

public class DoorOpener : MonoBehaviour {
	public float motorForce = 100;
	public float MotorRunningTime=1;
	float timeMotorHasRunFor=2;
	HingeJoint joint;
	JointMotor orginal;
	bool orginalMotor=true;
	// Use this for initialization
	void Start () {
		joint = GetComponentInParent<HingeJoint> ();
		orginal = joint.motor;
	}
	
	// Update is called once per frame
	void Update () {
		timeMotorHasRunFor += Time.deltaTime;
		if(timeMotorHasRunFor>MotorRunningTime){
			if(!orginalMotor){
				orginalMotor = true;
				joint.motor = orginal;
			}
		}
	}

	public void Open(int direction){
		if(timeMotorHasRunFor>MotorRunningTime){
			JointMotor motor = new JointMotor ();
			motor.force = motorForce*direction;
			joint.motor = motor;
			orginalMotor = false;
		}
	}
}
