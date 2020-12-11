using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    bool isRotating = false;

    private float journeyTime;
    private float startTime;
    private float fracComplete;
    Transform target;
    Vector3 angle;


    public bool RotateTarget(Transform target, float[] angle, float waitTime)
    {
        //Debug.Log("[ RotateTarget ] : waitTime = " + waitTime + " | Time = " + Time.time + " | Stat = " + isRotating);

        if (isRotating) return false;
        isRotating = true;
        startTime = Time.time;
        journeyTime = waitTime - waitTime/5;

        this.target = target;
        this.angle = new Vector3(angle[0], angle[1], angle[2]);

        return true;
    }

    private void FixedUpdate()
    {
        if (isRotating)
        {
            if (target.rotation.y < 180)
            {
                fracComplete = (Time.time - startTime) / journeyTime;
                //Debug.Log("{{ Frac Completed: " + fracComplete + " }}");

                target.rotation = Quaternion.Slerp(target.rotation, Quaternion.Euler(angle), fracComplete);

                if (Mathf.Abs(fracComplete) >= 1.0f) isRotating = false;
            }
            else
            {
                target.rotation = Quaternion.Euler(angle[0], angle[1], angle[2]); // try to avoid
                //Debug.Log("Finished Rotating at:" + Time.time);
            }
        }

    }
}
