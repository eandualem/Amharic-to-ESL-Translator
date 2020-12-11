using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slerp : MonoBehaviour
{
    private bool isSlerping = false;

    private float journeyTime;
    private float startTime;
    private float fracComplete;

    private Transform slerpTransform;

    private Vector3 start;
    private Vector3 target;
    private Vector3 direction;
    private Vector3 center;
    private Vector3 riseRelCenter;
    private Vector3 setRelCenter;


    public bool slerp(Transform tr, Vector3 targetPos, Vector3 direction, float time)
    {
        //Debug.Log("--------------------------SLerper--------------------------------" + Time.time);
        //Debug.Log("direction: " + direction + " | start: " + tr.position + " | target: " + targetPos + " | sisSlerping: " + isSlerping);

        if (isSlerping)
        {
            return false;
        }

        isSlerping = true;
        startTime = Time.time;
        journeyTime = time;
        target = targetPos;
        start = transform.position;
        slerpTransform = tr;
        this.direction = direction;

        return true;
    }

    public IEnumerator Zigzag(Transform tr, Vector3 targetPos, float time)
    {
        float partitions = 3;
        Vector3 start = tr.position;
        Vector3 diference = (targetPos - start) / partitions; // split totall distance

        slerp(tr, start + (diference), new Vector3(-0.1f, 0, 0), time / partitions);
        yield return new WaitForSeconds(time / partitions);
        slerp(tr, start + (2 * diference), new Vector3(0.1f, 0, 0), time / partitions);
        yield return new WaitForSeconds(time / partitions);
        slerp(tr, start + (3 * diference), new Vector3(-0.1f, 0, 0), time / partitions);
    }

    public IEnumerator Circle(Transform tr, Vector3 targetPos, string dir, float time)
    {
        Vector3 start = tr.position;

        if (dir == "V")
        {
            slerp(transform, targetPos, Vector3.up, time / 2);
            yield return new WaitForSeconds(time / 2);
            slerp(transform, start, Vector3.down, time / 2);
        }
        else
        {
            slerp(tr, targetPos, Vector3.left, time / 2);
            yield return new WaitForSeconds(time / 2);
            slerp(tr, start, Vector3.right, time / 2);
        }
    }


    void Update()
    {
        if (isSlerping)
        {
            center = (start + target) * 0.5F;
            center -= direction;
            riseRelCenter = start - center;
            setRelCenter = target - center;

            fracComplete = (Time.time - startTime) / journeyTime;

            slerpTransform.position = Vector3.Slerp(riseRelCenter, setRelCenter, fracComplete);
            slerpTransform.position += center;

            if (slerpTransform.position == target)
            {
                isSlerping = false;

                //Debug.Log("-------------------------- Finish --------------------------------" + Time.time);
            }
        }
    }

}
