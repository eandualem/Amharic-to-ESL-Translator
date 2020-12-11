using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHandController : MonoBehaviour
{
    private float ang = 90.0f;
    private float waitTime;
    private Move move;

    // right hand finger joins
    public Transform thumb;
    public Transform index;
    public Transform middle;
    public Transform ring;
    public Transform pinky;

    private HandConfig  handConfig  = new HandConfig();
    private Vector3[]   startRot    = new Vector3[15];
    private Transform[] fingers     = new Transform[5];

    private string  startConf;
    private string  endConf;
    private float[] xAngle;
    private float[] zAngle;


    public bool moveFinger(string startConf, string endConf, float waitTime)
    {
        // Debug.Log("Right Hand Fingers startConf: " + startConf);
        // Debug.Log("Right Hand Fingers endConf: "   + endConf);

        this.move = GameObject.Find("RightArmTarget").GetComponent<Move>();

        this.startConf = startConf;
        this.endConf = endConf;
        this.waitTime = waitTime / 2;

        fingers[0] = thumb;
        fingers[1] = index;
        fingers[2] = middle;
        fingers[3] = ring;
        fingers[4] = pinky;

        this.CallWithDelay(0f, InitialFingerConfiguration);
        
        if (!String.IsNullOrEmpty(endConf)) 
            this.CallWithDelay(waitTime/2, FinalFingerConfiguration);

        return true;
    }

    void InitialFingerConfiguration()
    {
        this.handConfig.configure(this.startConf.ToCharArray());
        move_finger(this.handConfig.conf_x_thumb, this.handConfig.conf_y_thumb, this.handConfig.conf_x, this.handConfig.conf_y);

    }
    void FinalFingerConfiguration()
    {
        this.handConfig.configure(this.endConf.ToCharArray());
        move_finger(this.handConfig.conf_x_thumb, this.handConfig.conf_y_thumb, this.handConfig.conf_x, this.handConfig.conf_y);
    }

    private void move_finger(HandConfig.finger_conf_X_Thumb conf_x_thumb, HandConfig.finger_conf_Y_Thumb conf_y_thumb, HandConfig.finger_conf_X[] conf_x, HandConfig.finger_conf_Y[] conf_y)
    {
        for (int f = 0; f < 5; f++)
        {
            xAngle = new float[] { 0, 0, 0 };
            zAngle = new float[] { 0, 0, 0 };

            if (f == 0) // thumb
            {
                switch (conf_x_thumb)
                {
                    // ----------------------------------------------------------- 0 ----------------- 1 ----------------- 2 ------------- //
                    case HandConfig.finger_conf_X_Thumb.Straight:                                                                       break;
                    case HandConfig.finger_conf_X_Thumb.RightAngle:                             zAngle[1] = ang/3;  zAngle[2] = ang/3;  break;
                    case HandConfig.finger_conf_X_Thumb.SlightlyRightAngle:                     zAngle[1] = ang/6;  zAngle[2] = ang/6;  break;
                    case HandConfig.finger_conf_X_Thumb.Forward:                                xAngle[1] = ang/3;  xAngle[2] = ang/3;  break;
                    case HandConfig.finger_conf_X_Thumb.SlightlyForward:    zAngle[0] = ang/3;  zAngle[1] = ang/3;  xAngle[2] = ang/2;   
                                                                                                                    zAngle[2] = -ang/6; break;
                    case HandConfig.finger_conf_X_Thumb.YRotated:                               zAngle[1] = -ang/2; xAngle[2] = ang/3;  break;
                                                                                                                    zAngle[2] = -ang/2;  break;
                    default: throw new Exception("Invalid Configuration");
                }

                switch (conf_y_thumb)
                {
                    case HandConfig.finger_conf_Y_Thumb.BentIn:
                        xAngle[0] = -10;     
                        zAngle[0] = -24;
                        // xAngle[1] = -20;     
                        // zAngle[1] = -48;
                        break;   

                    case HandConfig.finger_conf_Y_Thumb.BentOut:
                        xAngle[0] = 10;     
                        zAngle[0] = 24;
                        break;   

                    case HandConfig.finger_conf_Y_Thumb.Straight: 
                        break;

                    default: throw new Exception("Invalid Configuration");
                }
            }
            else // The rest of fingers
            {
                switch (conf_x[f-1])
                {
                    // ---------------------------------------------------- 0 ------------------- 1 ------------------- 2 --------------- //
                    case HandConfig.finger_conf_X.Straight:                                                                           break;
                    case HandConfig.finger_conf_X.OneBentIn:                                                     xAngle[2] = ang;     break;
                    case HandConfig.finger_conf_X.TwoBentIn:         xAngle[0] = ang;      xAngle[1] = ang;                           break;
                    case HandConfig.finger_conf_X.TwoSlitleyBentIn:  xAngle[0] = ang / 2;  xAngle[1] = ang / 2;                       break;
                    case HandConfig.finger_conf_X.AllSlitleyBentIn:  xAngle[0] = ang / 2;  xAngle[1] = ang / 2;  xAngle[2] = ang / 2; break;
                    case HandConfig.finger_conf_X.AllBentIn:         xAngle[0] = ang;      xAngle[1] = ang;      xAngle[2] = ang;     break;

                    default: throw new Exception("Invalid Configuration");
                }

                switch (conf_y[f-1])
                {
                    case HandConfig.finger_conf_Y.Open:

                        if (f == 1) // index
                        {
                            zAngle[2] += ang/12; 
                            break;
                        }
                        else if (f == 2) // middle
                        {
                            zAngle[2] += ang/12; 
                            break;
                        }
                        else if (f == 3) // ring
                        {
                            zAngle[2] += -ang/12; 
                            break;
                        }
                        else if (f == 4) // pinky
                        {
                            zAngle[2] += -ang/6; 
                            break;
                        }
                        else 
                        {
                            throw new Exception("Index out of bound");
                        }
                        

                    case HandConfig.finger_conf_Y.Entwined: 
                        
                        if (f == 1) // index
                        {
                            xAngle[2] += ang/15; 
                            zAngle[2] += -ang/10; 
                            break;
                        }
                        else if (f == 2) // middle
                        {
                            zAngle[2] += -ang/8; 
                            break;
                        }
                        else if (f == 3) // ring
                        {
                            xAngle[2] += ang/15; 
                            zAngle[2] += ang/10; 
                            break;
                        }
                        else if (f == 4) // pinky
                        {
                            xAngle[2] += ang/9; 
                            zAngle[2] += ang/6; 
                            break;
                        }
                        else
                        {
                            throw new Exception("Index out of bound");
                        }

                    case HandConfig.finger_conf_Y.Closed: break;

                    default: throw new Exception("Invalid Configuration");
                }
            }

            Transform fj = fingers[f]; // fj is for Finger joint

            for (int i = 0; i < 3; i++)
            {
                Vector3 angle = new Vector3(xAngle[i], 0f, zAngle[i]);
                Vector3 updated_angle = new Vector3(angle.x - startRot[f*3 + i].x, 0f, angle.z - startRot[f*3 + i].z);

                //StartCoroutine(this.move.RotateFinger(fj ,updated_angle, this.waitTime));

                fj.Rotate(updated_angle, Space.Self);

                fj = fj.parent;

                // update current
                startRot[f*3 + i].x += updated_angle.x;
                startRot[f*3 + i].z += updated_angle.z;
            }
        }
    }
}