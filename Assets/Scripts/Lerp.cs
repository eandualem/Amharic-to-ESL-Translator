using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerp : MonoBehaviour
{
//     // lerp variables
//     private Transform Obj;
//     private bool isLerping = false;
//     private Vector3 startPos;
//     private Vector3 targetPos;
//     private float timeElapsed = 0;
//     private float lerpDuration;

//     private Vector3 velocity;


//     public bool lerper(Transform obj, Vector3 targetPos, float time)
//     {
//         Debug.Log("Lerper called at =>  Time: "+ Time.time);

//         // if (isLerping)
//         // {
//         //     throw new Exception("Already moving");
//         // }

//         isLerping = true;
//         Obj = obj;
//         startPos = obj.position;
//         targetPos = targetPos;
//         lerpDuration = time;
//         velocity = Vector3.zero;

//         return true;
//     }

//     private void FixedUpdate()
//     {
//         Obj.position = Vector3.SmoothDamp(this.startPos, this.targetPos, ref velocity, 0.1f);
//     }
}
