using System;
using UnityEngine;

public class AnimationBiulder
{
    private Vector3 rightArmPosition            = new Vector3(0, 0, 0);
    private Vector3 leftArmPosition             = new Vector3(0, 0, 0);
    private string rightHandOrientation         = null;
    private string leftHandOrientation          = null;
    private string rightHandConfigration        = "F0X0Y0F1X0Y0F2X0Y0F3X0Y0F4X0Y0";
    private string leftHandConfigration         = "F0X0Y0F1X0Y0F2X0Y0F3X0Y0F4X0Y0";
    private string rightHandTransition          = null;
    private string leftHandTransition           = null;
    private Vector3 rightArmPositionFinal       = new Vector3(0, 0, 0);
    private Vector3 leftArmPositionFinal        = new Vector3(0, 0, 0);
    private string rightHandOrientationFinal    = null;
    private string leftHandOrientationFinal     = null;
    private string rightHandConfigrationFinal   = "F0X0Y0F1X0Y0F2X0Y0F3X0Y0F4X0Y0";
    private string leftHandConfigrationFinal    = "F0X0Y0F1X0Y0F2X0Y0F3X0Y0F4X0Y0";

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
