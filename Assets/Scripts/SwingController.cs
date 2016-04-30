using UnityEngine;
using System.Collections;

// This script controls vine swing movement

public class SwingController : MonoBehaviour {

    public float angle = -90.0f;
    public float speed = 1.5f;

    Quaternion qStart, qEnd;

    // Use this for initialization
    void Start () {
        qStart = Quaternion.AngleAxis(angle, Vector3.forward);
        qEnd = Quaternion.AngleAxis(-angle, Vector3.forward);
    }
	
	// Update is called once per frame
	void Update () {
        // Linearly interporate between 2 angles
        // http://docs.unity3d.com/ScriptReference/Quaternion.Lerp.html
        // http://answers.unity3d.com/questions/415996/motion-script-for-simple-pendulum.html
        transform.rotation = Quaternion.Lerp(qStart, qEnd, (Mathf.Sin(Time.time * speed) + 1.0f) / 2.0f);
        transform.Rotate(0, 0, 90, Space.Self);
    }
}
