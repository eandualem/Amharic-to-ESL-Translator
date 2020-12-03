using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnimationController: MonoBehaviour
{
    public RightArmController rightArmController;
    public LeftArmController leftArmController;
    public RightHandController rightHandController;
    public LeftHandController leftHandController;
    public RightHandOrientationController rightHandOrientationController;
    public LeftHandOrientationController leftHandOrientationController;

    private List<UnitAnimation> currentAnimations;
    private float waitTime;
    private int anim_index;


    private void Start()
    {
        rightArmController              = GameObject.Find("RightArmTarget").GetComponent<RightArmController>();
        leftArmController               = GameObject.Find("LeftArmTarget").GetComponent<LeftArmController>();
        rightHandController             = GameObject.Find("RightArmTarget").GetComponent<RightHandController>();
        leftHandController              = GameObject.Find("LeftArmTarget").GetComponent<LeftHandController>();
        rightHandOrientationController  = GameObject.Find("RightArmTarget").GetComponent<RightHandOrientationController>();
        leftHandOrientationController   = GameObject.Find("LeftArmTarget").GetComponent<LeftHandOrientationController>();
    }

    public void DisplayResult(Result result, float waitTime)
    {
        Start(); // I Don't know why this is necesary?
        anim_index = 0;
        this.currentAnimations = result.unit;
        this.waitTime = waitTime;

        for (int i = 0; i < this.currentAnimations.Count; i++)
        {
            this.CallWithDelay(this.waitTime*i, AnimationRunner);
        }
    }

    void AnimationRunner()
    { 
        // Debug.Log("Animation: " + anim_index + " |  Time: "+ Time.time);

        Animate(this.currentAnimations[anim_index]);
        anim_index++;
    }

    private void Animate(UnitAnimation unit) 
    {
        // Right Arm
        rightArmController.moveArm(unit.rightArmPosition, unit.rightArmPositionFinal, unit.rightHandTransition, this.waitTime);
        rightHandOrientationController.ReOrient(unit.rightHandOrientation, unit.rightHandOrientationFinal, this.waitTime);
        rightHandController.moveFinger(unit.rightHandConfigration, unit.rightHandConfigrationFinal, this.waitTime);

        // Left Arm
        // leftArmController.moveArm(unit.leftArmPosition, unit.leftArmPositionFinal, unit.leftHandTransition, this.waitTime);
        // leftHandOrientationController.ReOrient(unit.leftHandOrientation, unit.leftHandOrientationFinal, this.waitTime);
        // leftHandController.moveFinger(unit.leftHandConfigration, unit.leftHandConfigrationFinal, this.waitTime);
    }
}
