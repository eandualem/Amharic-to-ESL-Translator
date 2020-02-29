using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHandOrientationController : MonoBehaviour
{
    public Transform leftHandTarget;
    private Rotate rotate;
    private float speed = 1.0f;

    private float ang = 90.0f;

    public bool ReOrient(string initialOrientation, string finalOrientation, float speed, float waitTime)
    {
        rotate = GameObject.Find("LeftArmTarget").GetComponent<Rotate>();

        this.speed = speed;
        Orient(initialOrientation);
        StartCoroutine(Wait(waitTime));
        Orient(finalOrientation);

        return true;
    }
    IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }


    private bool Orient(string ori) 
    {
        switch (ori)
        {
            case "A": rotate_x(0.0f); rotate_y(0.0f); rotate_z(0.0f); return true;
            case "B": rotate_x(0f); rotate_y(0f); rotate_z(0f); return true;
            case "C": rotate_x(0f); rotate_y(0f); rotate_z(0f); return true;
            case "D": rotate_x(0f); rotate_y(0f); rotate_z(0f); return true;
            case "E": rotate_x(0f); rotate_y(0f); rotate_z(0f); return true;
            case "F": rotate_x(0f); rotate_y(0f); rotate_z(0f); return true;
            case "G": rotate_x(-ang); rotate_y(-ang); rotate_z(0f); return true;
            case "H": rotate_x(-ang); rotate_y(0f); rotate_z(0f); return true;
            case "I": rotate_x(-ang); rotate_y(ang); rotate_z(0f); return true;
            case "J": rotate_x(0f); rotate_y(0f); rotate_z(0f); return true;
            case "K": rotate_x(0f); rotate_y(0f); rotate_z(0f); return true;
            case "L": rotate_x(0f); rotate_y(0f); rotate_z(0f); return true;
            default: return false;
        }
    }

    void rotate_x(float angle)
    {
        rotate.RotateTarget(leftHandTarget, new float[] { angle, 0, 0 }, speed);
    }

    void rotate_y(float angle)
    {
        rotate.RotateTarget(leftHandTarget, new float[] { 0, angle, 0 }, speed);
    }

    void rotate_z(float angle)
    {
        rotate.RotateTarget(leftHandTarget, new float[] { 0, 0, angle }, speed);
    }
}
