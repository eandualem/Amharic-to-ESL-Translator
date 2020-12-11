using UnityEngine;

public class UnitAnimation
{

    public readonly Vector3 rightArmPosition;
    public readonly Vector3 leftArmPosition;
    public readonly string  rightHandOrientation;
    public readonly string  leftHandOrientation;
    public readonly string  rightHandConfigration;
    public readonly string  leftHandConfigration;
    public readonly string  rightHandTransition;
    public readonly string  leftHandTransition;
    public readonly Vector3 rightArmPositionFinal;
    public readonly Vector3 leftArmPositionFinal;
    public readonly string  rightHandOrientationFinal;
    public readonly string  leftHandOrientationFinal;
    public readonly string  rightHandConfigrationFinal;
    public readonly string  leftHandConfigrationFinal;

    public UnitAnimation(
                          Vector3 rightArmPosition,
                          Vector3 leftArmPosition, 
                          string  rightHandOrientation,
                          string  leftHandOrientation, 
                          string  rightHandConfigration, 
                          string  leftHandConfigration,
                          string  rightHandTransition, 
                          string  leftHandTransition,
                          Vector3 rightArmPositionFinal,
                          Vector3 leftArmPositionFinal, 
                          string  rightHandOrientationFinal,
                          string  leftHandOrientationFinal, 
                          string  rightHandConfigrationFinal, 
                          string  leftHandConfigrationFinal
                          )
    {
        this.rightArmPosition           = rightArmPosition;
        this.leftArmPosition            = leftArmPosition;
        this.rightHandOrientation       = rightHandOrientation;
        this.leftHandOrientation        = leftHandOrientation;
        this.rightHandConfigration      = rightHandConfigration;
        this.leftHandConfigration       = leftHandConfigration;
        this.rightHandTransition        = rightHandTransition;
        this.leftHandTransition         = leftHandTransition;
        this.rightArmPositionFinal      = rightArmPositionFinal;
        this.leftArmPositionFinal       = leftArmPositionFinal;
        this.rightHandOrientationFinal  = rightHandOrientationFinal;
        this.leftHandOrientationFinal   = leftHandOrientationFinal;
        this.rightHandConfigrationFinal = rightHandConfigrationFinal;
        this.leftHandConfigrationFinal  = leftHandConfigrationFinal;
    }
}
