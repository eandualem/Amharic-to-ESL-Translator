using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftArmController : MonoBehaviour
{
    // private Lerp lerp;
    // private Slerp slerp;

    // public bool moveArm(Vector3 start, Vector3 target, string transition, float waitTime)
    // {
    //     StartCoroutine(moveToTarget(start, target, transition, waitTime));
    //     return true;
    // }

    // public IEnumerator moveToTarget(Vector3 start, Vector3 target, string transition, float waitTime)
    // {
    //     // Optimal values for speed
    //     float lerpSpeed = 1.5f / waitTime;
    //     float slerpSpeed = waitTime / 2f;

    //     // Update pos for right arm
    //     Vector3 startPos = new Vector3(start.x + 0.2f, start.y, start.z);
    //     Vector3 targetPos = new Vector3(target.x + 0.2f, target.y, target.z);

    //     slerp = GameObject.Find("LeftArmTarget").GetComponent<Slerp>();
    //     lerp = GameObject.Find("LeftArmTarget").GetComponent<Lerp>();

    //     LinearMovement(startPos, lerpSpeed);

    //     yield return new WaitForSeconds(waitTime / 2);

    //     switch (transition)
    //     {
    //         case "A": LinearMovement(targetPos, lerpSpeed); break;
    //         case "B": CurvedMovementUp(targetPos, slerpSpeed); break;
    //         case "C": CurvedMovementDown(targetPos, slerpSpeed); break;
    //         case "D": CurvedMovementLeft(targetPos, slerpSpeed); break;
    //         case "E": CurvedMovementRight(targetPos, slerpSpeed); break;
    //         case "F": ZigzagMovement(targetPos, slerpSpeed); break;
    //         case "G": CircularMovementHorizontal(targetPos, slerpSpeed); break;
    //         case "H": CircularMovementVertical(targetPos, slerpSpeed); break;

    //     }
    // }

    // private void LinearMovement(Vector3 targetPos, float speed)
    // {
    //     lerp.lerper(transform, targetPos, speed);
    // }
    // private void CurvedMovementUp(Vector3 targetPos, float speed)
    // {
    //     slerp.slerp(transform, targetPos, Vector3.up, speed);
    // }
    // private void CurvedMovementDown(Vector3 targetPos, float speed)
    // {
    //     slerp.slerp(transform, targetPos, Vector3.down, speed);
    // }
    // private void CurvedMovementLeft(Vector3 targetPos, float speed)
    // {
    //     slerp.slerp(transform, targetPos, Vector3.left, speed);
    // }
    // private void CurvedMovementRight(Vector3 targetPos, float speed)
    // {
    //     slerp.slerp(transform, targetPos, Vector3.right, speed);
    // }
    // private void ZigzagMovement(Vector3 targetPos, float speed)
    // {
    //     StartCoroutine(slerp.Zigzag(transform, targetPos, speed));
    // }
    // private void CircularMovementHorizontal(Vector3 targetPos, float speed)
    // {
    //     StartCoroutine(slerp.Circle(transform, targetPos, "H", speed));
    // }
    // private void CircularMovementVertical(Vector3 targetPos, float speed)
    // {
    //     StartCoroutine(slerp.Circle(transform, targetPos, "V", speed));
    // }
}
