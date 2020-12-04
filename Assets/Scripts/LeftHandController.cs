using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHandController : MonoBehaviour
{
     // right hand finger joins
    // public Transform thumb;
    // public Transform index;
    // public Transform middle;
    // public Transform ring;
    // public Transform pinky;

    // private float ang = 90.0f;

    // Transform[] fingers = new Transform[5];
    // Vector3[] startRot = new Vector3[15];
    // HandConfig handConfig = new HandConfig();

    // float[] xAngle;
    // float[] zAngle;

    // string startConf;
    // string endConf;


    // public bool moveFinger(string startConf, string endConf, float waitTime)
    // {
    //     Debug.Log("startConf: " + startConf);
    //     Debug.Log("endConf: " + endConf);

    //     this.startConf = startConf;
    //     this.endConf = endConf;

    //     fingers[0] = thumb;
    //     fingers[1] = index;
    //     fingers[2] = middle;
    //     fingers[3] = ring;
    //     fingers[4] = pinky;

    //     this.CallWithDelay(0f,          InitialFingerConfiguration);
    //     this.CallWithDelay(waitTime/2,  FinalFingerConfiguration);

    //     return true;
    // }

    // void InitialFingerConfiguration()
    // {
    //     this.handConfig.configure(this.startConf.ToCharArray());
    //     move_finger(this.handConfig.conf_x, this.handConfig.conf_y);

    // }
    // void FinalFingerConfiguration()
    // {
    //     this.handConfig.configure(this.endConf.ToCharArray());
    //     move_finger(this.handConfig.conf_x, this.handConfig.conf_y);
    // }

    // private void move_finger(HandConfig.finger_conf_X[] conf_x, HandConfig.finger_conf_Y[] conf_y)
    // {
    //     // ---------------------------------Debug------------------------------------------------
    //     string test = "";
    //     foreach (var item in conf_x)
    //     {
    //         test += "| x : " + item;
    //     }
    //     Debug.Log(test);
    //     // -------------------------------------------------------------------------------------

    //     for (int f = 0; f < 5; f++)
    //     {
    //         xAngle = new float[] { 0, 0, 0 };
    //         zAngle = new float[] { 0, 0, 0 };

    //         if (f == 0) // thumb
    //         {
    //             switch (conf_x[f])
    //             {
    //                 // ---------------------------------------------- 0  ------------------ 1 ----------------- 2 ------------------ //
    //                 case HandConfig.finger_conf_X.Straight:                                                                       break;
    //                 case HandConfig.finger_conf_X.OneBent:                                                   xAngle[2] = ang/2;   break;
    //                 case HandConfig.finger_conf_X.TwoSlitleyBent:  zAngle[0] = ang/3;  zAngle[1] = ang/4;  xAngle[2] = ang/2;   break;
    //                 case HandConfig.finger_conf_X.TwoBent:         zAngle[0] = ang/2;  zAngle[1] = ang/3;  xAngle[2] = ang/2;   break;
    //                 // Unique for thumb, BentOutt is AllSlitleyBent and 
    //                 case HandConfig.finger_conf_X.AllSlitleyBent:  zAngle[0] = -ang/4;   zAngle[1] =  -ang/4;  xAngle[2] = ang/2;   
    //                                                                                                          zAngle[2] = ang/6;  break;
    //                 case HandConfig.finger_conf_X.AllBent:                                                   xAngle[2] = ang*2/3;
    //                                                                                                          zAngle[2] = ang/6;  break;
                    
    //                 default: throw new Exception("Invalid Configuration");
    //             }
    //         }
    //         else // The rest of fingers
    //         {
    //             switch (conf_x[f])
    //             {
    //                 // ---------------------------------------------- 0  ------------------ 1 ------------------- 2 ------------------ //
    //                 case HandConfig.finger_conf_X.Straight:                                                                         break;
    //                 case HandConfig.finger_conf_X.OneBent:                                                     xAngle[2] = ang;     break;
    //                 case HandConfig.finger_conf_X.TwoSlitleyBent:  xAngle[0] = ang / 2;  xAngle[1] = ang / 2;                       break;
    //                 case HandConfig.finger_conf_X.TwoBent:         xAngle[0] = ang;      xAngle[1] = ang;                           break;
    //                 case HandConfig.finger_conf_X.AllSlitleyBent:  xAngle[0] = ang / 2;  xAngle[1] = ang / 2;  xAngle[2] = ang / 2; break;
    //                 case HandConfig.finger_conf_X.AllBent:         xAngle[0] = ang;      xAngle[1] = ang;      xAngle[2] = ang;     break;

    //                 default: throw new Exception("Invalid Configuration");
    //             }
    //         }
    //         switch (conf_y[f])
    //         {
    //             case HandConfig.finger_conf_Y.Open:
    //                 if (f == 0) // thumb
    //                 {
    //                     zAngle[2] = -ang/6; break;
    //                 }
    //                 else if (f == 1) // index
    //                 {
    //                     zAngle[2] = -ang/6; break;
    //                 }
    //                 else if (f == 3 | f == 4) // ring
    //                 {
    //                     zAngle[2] = ang/10; break;
    //                 }
    //                 else if (f == 3 | f == 4) // pinky
    //                 {
    //                     zAngle[2] = ang/6; break;
    //                 }
    //                 else // middle
    //                 {
    //                     break;
    //                 }

    //             case HandConfig.finger_conf_Y.Closed: break;

    //             default: throw new Exception("Invalid Configuration");
    //         }

    //         Transform fj = fingers[f]; // fj is for Finger joint

    //         for (int i = 0; i < 3; i++)
    //         {
    //             Vector3 angle = new Vector3(xAngle[i], 0f, zAngle[i]);
    //             Vector3 updated_angle = new Vector3(angle.x - startRot[f*3 + i].x, 0f, angle.z - startRot[f*3 + i].z);

    //             fj.Rotate(updated_angle, Space.Self);
    //             fj = fj.parent;

    //             // update current
    //             startRot[f*3 + i].x += updated_angle.x;
    //             startRot[f*3 + i].z += updated_angle.z;
    //         }
    //     }
    // }
}
