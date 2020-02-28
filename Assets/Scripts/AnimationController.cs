using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController: MonoBehaviour
{
    public float waitTime   = 5.0f;
    public float lerpSpeed  = 1.0f;
    public float slerpSpeed = 1.0f;
    public float rotSpeed   = 1.0f;

    public RightArmController rightArmController;
    public LeftArmController leftArmController;
    public RightHandController rightHandController;
    public LeftHandController leftHandController;
    public RightHandOrientationController rightHandOrientationController;
    public LeftHandOrientationController leftHandOrientationController;

    void Start()
    {
        rightArmController = GameObject.Find("RightArmTarget").GetComponent<RightArmController>();
        leftArmController = GameObject.Find("RightArmTarget").GetComponent<LeftArmController>();
        rightHandController = GameObject.Find("RightArmTarget").GetComponent<RightHandController>();
        leftHandController = GameObject.Find("RightArmTarget").GetComponent<LeftHandController>();
        rightHandOrientationController = GameObject.Find("RightArmTarget").GetComponent<RightHandOrientationController>();
        leftHandOrientationController = GameObject.Find("RightArmTarget").GetComponent<LeftHandOrientationController>();
    }

    private void Animate(UnitAnimation unit) 
    {
        rightArmController.moveToTarget(unit.rightArmPosition, unit.rightArmPositionFinal, unit.rightHandTransition, lerpSpeed, slerpSpeed, waitTime);
        rightHandController.moveFinger(unit.rightHandConfigration, unit.rightHandConfigrationFinal, rotSpeed, waitTime);
        rightHandOrientationController.ReOrient(unit.rightHandOrientation, unit.rightHandOrientationFinal, rotSpeed, waitTime);
    }

    public void DisplayResult(FinalResult result)
    {
        //TO DO
        foreach (var anim in result.unit)
        {
            Animate(anim);
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);
    }
}
