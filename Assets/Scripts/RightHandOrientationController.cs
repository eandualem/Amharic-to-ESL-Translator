using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHandOrientationController : MonoBehaviour
{

    private float waitTime;

    private float   ang = 90.0f;
    private Rotate  rotate;
    private Move move;

    private string  initialOrientation;
    private string  finalOrientation;


    public bool ReOrient(string initialOrientation, string finalOrientation, float waitTime)
    {
        this.rotate = GameObject.Find("_Manager").GetComponent<Rotate>();
        this.move  = GameObject.Find("RightArmTarget").GetComponent<Move>();

        this.initialOrientation = initialOrientation;
        this.finalOrientation = finalOrientation;

        this.waitTime = waitTime/2; //Hamd should rotate faster.

        this.CallWithDelay(0f, InitialRotation);
        
        if (!String.IsNullOrEmpty(finalOrientation)) 
            this.CallWithDelay(waitTime/2, FinalRotation);

        return true;
    }

    void InitialRotation()
    {
        Orient(initialOrientation);
    }
    void FinalRotation()
    {
        Orient(finalOrientation);
    }

    private bool Orient(string ori) 
    {

        switch (ori)
        {
            case "A": RotateHand(new float[] {  0,        ang,     ang * 2  }); return true;
            case "B": RotateHand(new float[] {  0,        ang,    -ang      }); return true;
            case "C": RotateHand(new float[] {  0,        ang,     0        }); return true;

            case "D": RotateHand(new float[] { -ang * 2,  ang,     -ang * 2 }); return true;
            case "E": RotateHand(new float[] { -ang * 2,  ang,     -ang     }); return true;
            case "F": RotateHand(new float[] { -ang * 2,  ang,      0       }); return true;

            case "G": RotateHand(new float[] { -ang,     -ang * 2,  ang     }); return true;
            case "H": RotateHand(new float[] { -ang,     -ang * 2, -ang * 2 }); return true;
            case "I": RotateHand(new float[] { -ang,     -ang * 2, -ang     }); return true;

            case "J": RotateHand(new float[] {  ang,     -ang,      0       }); return true;
            case "K": RotateHand(new float[] {  ang,     -ang,      ang     }); return true;
            case "L": RotateHand(new float[] {  ang,     -ang,      ang * 2 }); return true;

            default: throw new Exception("Invalid Orientation.");
        }
    }

    void RotateHand(float[] angle)
    {
        // float[] curent = new float[] { transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z };
        // float[] newAngle = new float[] { angle[0] - curent[0], angle[1] - curent[1], angle[2] - curent[2]};
        // Debug.Log("newAngle = " +String.Join("", new List<float>(newAngle) 
        //                                             .ConvertAll(i => i.ToString())
        //                                             .ToArray()));
        // rotate.RotateTarget(transform, angle, this.waitTime);
        StartCoroutine(this.move.Rotate(angle, this.waitTime));
    }

}
