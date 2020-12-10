using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHandOrientationController : MonoBehaviour
{
    private Rotate rotate;
    private float waitTime;

    private float ang = 80.0f;

    public bool ReOrient(string initialOrientation, string finalOrientation, float waitTime)
    {
        rotate = GameObject.Find("LeftArmTarget").GetComponent<Rotate>();

        this.waitTime = waitTime / 2;

        StartCoroutine(RunAndWait(initialOrientation, finalOrientation));

        return true;
    }

    private IEnumerator RunAndWait(string initialOrientation, string finalOrientation)
    {
        Orient(initialOrientation);

        yield return new WaitForSeconds(waitTime);

        Orient(finalOrientation);
    }

    private bool Orient(string ori)
    {
        Debug.Log("---------ori: " + ori + " |  Time: " + Time.time);

        switch (ori)
        {
            case "A": RotateHand(new float[] { -2 * ang, -ang, 0.0f }); return true;

            case "B": RotateHand(new float[] { -2 * ang, -ang, ang }); return true;
            case "C": RotateHand(new float[] { -2 * ang, -ang, 2 * ang }); return true;

            case "D": RotateHand(new float[] { 0.0f, -ang, 0.0f }); return true;
            case "E": RotateHand(new float[] { 0.0f, -ang, ang }); return true;
            case "F": RotateHand(new float[] { 0.0f, -ang, 2 * ang }); return true;

            case "G": RotateHand(new float[] { -ang, 0.0f, -ang }); return true;
            case "H": RotateHand(new float[] { -ang, 0.0f, 0.0f }); return true;
            case "I": RotateHand(new float[] { -ang, 0.0f, ang }); return true;

            case "J": RotateHand(new float[] { ang, -ang, 0.0f }); return true;
            case "K": RotateHand(new float[] { ang, -ang, ang }); return true;
            case "L": RotateHand(new float[] { ang, -ang, 2 * ang }); return true;

            default: Debug.LogError("Invalid Orientation."); return false;
        }
    }

    void RotateHand(float[] angle)
    {
        //float[] curent = new float[] { transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z };
        //float[] newAngles = new float[] { angle[0] - curent[0], angle[1] - curent[1], angle[2] - curent[2]};
        rotate.RotateTarget(transform, angle, waitTime);
    }

}
