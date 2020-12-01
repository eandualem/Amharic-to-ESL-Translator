using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RightArmController : MonoBehaviour
{
    // private Lerp    lerp;
    private Slerp   slerp;
    private Move move;
    private Vector3 start;
    private Vector3 target;
    private string  transition;
    // private float   lerpduration; 
    // private float   slerpduration;
    private float waitTime;


    public bool moveArm(Vector3 start, Vector3 target, string transition, float waitTime)
    {
        this.start      = start;
        this.target     = target;
        this.transition = transition;
        this.waitTime = waitTime;

        this.slerp = GameObject.Find("_Manager").GetComponent<Slerp>();
        // this.lerp  = GameObject.Find("_Manager").GetComponent<Lerp>();
        this.move  = GameObject.Find("RightArmTarget").GetComponent<Move>();


        this.CallWithDelay(0f, Initialmove);
        
        if (!String.IsNullOrEmpty(transition)) 
            this.CallWithDelay(this.waitTime/3, Finalmove);
        
        return true;
    }

    void Initialmove()
    {
        Debug.Log("Initialmove at =>  Time: "+ Time.time);

        Vector3 startPos  = new Vector3(this.start.x  + 0.2f, this.start.y,  this.start.z );
        LinearMovement(startPos, this.waitTime/3);
    }
    void Finalmove()
    {
        Debug.Log("Finalmove at =>  Time: "+ Time.time);

        Vector3 targetPos = new Vector3(this.target.x + 0.2f, this.target.y, this.target.z);
        moveToTarget(targetPos);
    }

    public void moveToTarget(Vector3 targetPos)
    {
        
        LinearMovement(targetPos, this.waitTime*2/3);

        //  switch (this.transition)
        // {
        //     case "A": LinearMovement            (targetPos, this.waitTime * 2 / 3); break;
        //     case "B": CurvedMovementUp          (targetPos, this.waitTime * 2 / 3); break;
        //     case "C": CurvedMovementDown        (targetPos, this.waitTime * 2 / 3); break;
        //     case "D": CurvedMovementLeft        (targetPos, this.waitTime * 2 / 3); break;
        //     case "E": CurvedMovementRight       (targetPos, this.waitTime * 2 / 3); break;
        //     case "F": ZigzagMovement            (targetPos, this.waitTime * 2 / 3); break;
        //     case "G": CircularMovementHorizontal(targetPos, this.waitTime * 2 / 3); break;
        //     case "H": CircularMovementVertical  (targetPos, this.waitTime * 2 / 3); break;

        // }
    }

    private void LinearMovement(Vector3 targetPos, float duration) 
    {
        StartCoroutine(this.move.LinearMovement(targetPos, duration));
    }
    private void CurvedMovementUp(Vector3 targetPos, float duration)
    {
        StartCoroutine(this.move.CurvedMovementUp(targetPos, duration));
    }
    private void CurvedMovementDown(Vector3 targetPos, float duration)
    {
        StartCoroutine(this.move.CurvedMovementDown(targetPos, duration));
    }
    private void CurvedMovementLeft(Vector3 targetPos, float duration)
    {
        StartCoroutine(this.move.CurvedMovementLeft(targetPos, duration));
    }
    private void CurvedMovementRight(Vector3 targetPos, float duration)
    {
        StartCoroutine(this.move.CurvedMovementRight(targetPos, duration));
    }
    private void ZigzagMovement(Vector3 targetPos, float duration)
    {
        StartCoroutine(this.move.ZigzagMovement(targetPos, duration));
    }
    private void CircularMovementHorizontal(Vector3 targetPos, float duration)
    {
        StartCoroutine(this.move.CircularMovementHorizontal(targetPos, duration));
    }
    private void CircularMovementVertical (Vector3 targetPos, float duration)
    {
        StartCoroutine(this.move.CircularMovementVertical(targetPos, duration));
    }

}
