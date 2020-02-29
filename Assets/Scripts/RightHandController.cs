using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHandController : MonoBehaviour
{
    // right hand finger joins
    public Transform thumb;
    public Transform index;
    public Transform middle;
    public Transform ring;
    public Transform pinky;

    public enum finger_conf_X : int { Straight, OneBent, TwoBent, TwoSlitleyBent, AllSlitleyBent, AllBent };
    public enum finger_conf_Y : int { Open, Closed };
    Transform[] fingers = new Transform[5];

    private Rotate rotate;

    private float speed = 1.0f;

    private void move_finger(finger_conf_X[] conf_x, finger_conf_Y[] conf_y)
    {
        fingers[0] = thumb;
        fingers[1] = index;
        fingers[2] = middle;
        fingers[3] = ring;
        fingers[4] = pinky;

        float[] xAngle = new float[3];
        float[] zAngle = new float[3];

        for (int f = 0; f < 5; f++)
        {
            switch (conf_x[f])
            {
                case finger_conf_X.Straight:        xAngle = new float[] {  0,  0,  0 }; break;
                case finger_conf_X.OneBent:         xAngle = new float[] { 90,  0,  0 }; break;
                case finger_conf_X.TwoSlitleyBent:  xAngle = new float[] {  0, 45, 45 }; break;
                case finger_conf_X.TwoBent:         xAngle = new float[] {  0, 90, 90 }; break;
                case finger_conf_X.AllSlitleyBent:  xAngle = new float[] { 45, 45, 45 }; break;
                case finger_conf_X.AllBent:         xAngle = new float[] { 90, 90, 90 }; break;
            }

            switch (conf_y[f])
            {
                case finger_conf_Y.Open:    zAngle = new float[] { 15, 15, 15 }; break;
                case finger_conf_Y.Closed:  zAngle = new float[] {  0,  0,  0 }; break;
            }
            Transform fingerJoint = fingers[f];
            float[] angle = new float[3];
            for (int i = 0; i < 3; i++)
            {
                angle[0] = xAngle[i];
                angle[2] = zAngle[i];
                rotate.RotateTarget(fingerJoint, angle, speed);
                fingerJoint = fingerJoint.parent;
            }
        }
    }

    public bool moveFinger(string startConf, string endConf, float rotSpeed, float waitTime)
    {
        Debug.Log("------------------Conf----------------------------------");
        Debug.Log("Start Conf: " + startConf + "|   End Conf: " + endConf);
        Debug.Log("----------------------------------------------------");
        rotate = GameObject.Find("RightArmTarget").GetComponent<Rotate>();

        this.speed = rotSpeed;

        configure(startConf.ToCharArray());
        StartCoroutine(Wait(waitTime));
        configure(endConf.ToCharArray());

        return true;
    }


    IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }
    private void configure(char[] ca) 
    {
        finger_conf_X[] temp_x = { 
                                    map_x(ca[0].ToString() + ca[1].ToString()),
                                    map_x(ca[4].ToString() + ca[5].ToString()),
                                    map_x(ca[8].ToString() + ca[9].ToString()),
                                    map_x(ca[12].ToString() + ca[13].ToString()),
                                    map_x(ca[16].ToString() + ca[17].ToString())
                                   };
        finger_conf_Y[] temp_y = {
                                    map_y(ca[2].ToString() + ca[3].ToString()),
                                    map_y(ca[6].ToString() + ca[7].ToString()),
                                    map_y(ca[10].ToString() + ca[11].ToString()),
                                    map_y(ca[14].ToString() + ca[15].ToString()),
                                    map_y(ca[18].ToString() + ca[19].ToString())
                                   };
        move_finger(temp_x, temp_y);
    }
    //   F0X0Y0F1X0Y0F2X0Y0F3X0Y0F4X0Y0
    finger_conf_X map_x(string s)
    {
        switch (s)
        {
            case "X0": return finger_conf_X.Straight;
            case "X1": return finger_conf_X.OneBent;        
            case "X2": return finger_conf_X.TwoSlitleyBent; 
            case "X3": return finger_conf_X.TwoBent;        
            case "X4": return finger_conf_X.AllSlitleyBent; 
            case "X5": return finger_conf_X.AllBent;

            default: return finger_conf_X.Straight;
        }
    }

    finger_conf_Y map_y(string s)
    {
        switch (s)
        {
            case "Y0": return finger_conf_Y.Open;
            case "Y1": return finger_conf_Y.Closed;

            default: return finger_conf_Y.Open;
        }
    } 
}