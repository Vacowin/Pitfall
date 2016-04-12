using UnityEngine;
using System.Collections;

public class SwingController : MonoBehaviour {

    private HingeJoint2D joint;
    public float _motor;

    public float angle = -90.0f;
    public float speed = 1.5f;

    Quaternion qStart, qEnd;

    // Use this for initialization
    void Start () {
        joint = GetComponent<HingeJoint2D>();
        //joint
        qStart = Quaternion.AngleAxis(angle, Vector3.forward);
        qEnd = Quaternion.AngleAxis(-angle, Vector3.forward);
    }
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.Lerp(qStart, qEnd, (Mathf.Sin(Time.time * speed) + 1.0f) / 2.0f);
        transform.Rotate(0, 0, 90, Space.Self);
        /*
        float angle = joint.jointAngle;
        if (angle < - 88)
        {
            JointMotor2D motor = new JointMotor2D();
            motor.motorSpeed = 100;
            motor.maxMotorTorque = 10000;
            joint.motor = motor;
        }
        else if (angle > -2)
        {
            JointMotor2D motor = new JointMotor2D();
            motor.motorSpeed = -100;
            motor.maxMotorTorque = 10000;
            joint.motor = motor;
        }
        _motor = joint.motor.motorSpeed;
        */
    }
}
