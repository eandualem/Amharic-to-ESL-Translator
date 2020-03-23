using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerp : MonoBehaviour
{

    // lerp variables
    private Transform Obj;
    private bool isLerping = false;
    private Vector3 startLerpPos;
    private Vector3 targetLerpPos;
    private float lerpTime;
    private float lerpSpeed;

    public bool lerper(Transform obj, Vector3 targetPos, float speed)
    {
        //Debug.Log("--------------------------Lerper--------------------------------");

        //Debug.Log("rightArmPosition: " + targetPos + "isLerping: " + isLerping);

        //Debug.Log("----------------------------------------------------------------");

        if (isLerping)
        {
            return false;
        }

        isLerping = true;
        Obj = obj;
        startLerpPos = obj.position;
        targetLerpPos = targetPos;
        lerpTime = Time.time;
        lerpSpeed = speed;

        return true;
    }

    float JourneyFraction(float totalDistance, float startTime, float speed)
    {
        float currentDuration = (Time.time - startTime) * speed;
        float journeyFraction = currentDuration / totalDistance;

        return journeyFraction;
    }

    private void FixedUpdate()
    {
        if (isLerping)
        {
            float totalDistance = Vector3.Distance(startLerpPos, targetLerpPos);
            float journeyFraction = JourneyFraction(totalDistance, lerpTime, lerpSpeed);

            Obj.position = Vector3.Lerp(startLerpPos, targetLerpPos, journeyFraction);

            if (Mathf.Abs(journeyFraction) >= 1.0f)
            {
                isLerping = false;
            }
        }
    }
}
