using System;
using UnityEngine;

public class AnimationBiulder
{
    private Vector3 rightArmPosition;
    private Vector3 leftArmPosition;
    private string rightHandOrientation;
    private string leftHandOrientation;
    private string rightHandConfigration;
    private string leftHandConfigration;
    private string rightHandTransition;
    private string leftHandTransition;
    private Vector3 rightArmPositionFinal;
    private Vector3 leftArmPositionFinal;
    private string rightHandOrientationFinal;
    private string leftHandOrientationFinal;
    private string rightHandConfigrationFinal;
    private string leftHandConfigrationFinal;

    public AnimationBiulder RightArmPosition(Vector3 rightArmPosition)
    {
        this.rightArmPosition = rightArmPosition;
        return this;
    }
    public AnimationBiulder LeftArmPosition(Vector3 leftArmPosition)
    {
        this.leftArmPosition = leftArmPosition;
        return this;
    }
    public AnimationBiulder RightHandOrientation(string rightHandOrientation)
    {
        this.rightHandOrientation = rightHandOrientation;
        return this;
    }
    public AnimationBiulder LeftHandOrientation(string leftHandOrientation)
    {
        this.leftHandOrientation = leftHandOrientation;
        return this;
    }
    public AnimationBiulder RightHandConfigration(string rightHandConfigration)
    {
        this.rightHandConfigration = rightHandConfigration;
        return this;
    }
    public AnimationBiulder LeftHandConfigration(string leftHandConfigration)
    {
        this.leftHandConfigration = leftHandConfigration;
        return this;
    }
    public AnimationBiulder LeftHandTransition(string rightHandTransition)
    {
        this.rightHandTransition = rightHandTransition;
        return this;
    }
    public AnimationBiulder RightHandTransition(string rightHandTransition)
    {
        this.rightHandTransition = rightHandTransition;
        return this;
    }
    public AnimationBiulder RightArmPositionFinal(Vector3 rightArmPositionFinal)
    {
        this.rightArmPositionFinal = rightArmPositionFinal;
        return this;
    }
    public AnimationBiulder LeftArmPositionFinal(Vector3 leftArmPositionFinal)
    {
        this.leftArmPositionFinal = leftArmPositionFinal;
        return this;
    }
    public AnimationBiulder RightHandOrientationFinal(string rightHandOrientationFinal)
    {
        this.rightHandOrientationFinal = rightHandOrientationFinal;
        return this;
    }
    public AnimationBiulder LeftHandOrientationFinal(string leftHandOrientationFinal)
    {
        this.leftHandOrientationFinal = leftHandOrientationFinal;
        return this;
    }
    public AnimationBiulder RightHandConfigrationFinal(string rightHandConfigrationFinal)
    {
        this.rightHandConfigrationFinal = rightHandConfigrationFinal;
        return this;
    }
    public AnimationBiulder LeftHandConfigrationFinal(string leftHandConfigrationFinal)
    {
        this.leftHandConfigrationFinal = leftHandConfigrationFinal;
        return this;
    }

    // ....
    public UnitAnimation Build() 
    {
        UnitAnimation unit = new UnitAnimation(
                                                this.rightArmPosition,
                                                this.leftArmPosition,
                                                this.rightHandOrientation,
                                                this.leftHandOrientation,
                                                this.rightHandConfigration,
                                                this.leftHandConfigration,
                                                this.rightHandTransition,
                                                this.leftHandTransition,
                                                this.rightArmPositionFinal,
                                                this.leftArmPositionFinal,
                                                this.rightHandOrientationFinal,
                                                this.leftHandOrientationFinal,
                                                this.rightHandConfigrationFinal,
                                                this.leftHandConfigrationFinal );
        return unit;
    }
}
