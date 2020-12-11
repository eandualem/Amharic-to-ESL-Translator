using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Move : MonoBehaviour
{
    float time;
    float t;
    
    public IEnumerator LinearMovement(Vector3 target, float duration)
    {
        // Debug.Log("Started at =>  Time: "+ Time.time);
        Vector3 startPos = transform.position;

        time = 0;
        while (time < duration)
        {
            t = time / duration;
            t = t*t*t * (t * (6f*t - 15f) + 10f);

            transform.position = Vector3.Lerp(startPos, target, t);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = target;

        // Debug.Log("Finished at =>  Time: "+ Time.time);
    }

    public IEnumerator Rotate(float[] angle, float duration)
    {
        // Debug.Log("Started at =>  Time: "+ Time.time);

        Quaternion startAngle = transform.rotation;
        Quaternion targetAngle = Quaternion.Euler(angle[0], angle[1], angle[2]);

        time = 0;
        while (time < duration)
        {
            t = time / duration;
            t = Mathf.Sin(t * Mathf.PI * 0.5f);

            transform.rotation = Quaternion.Lerp(startAngle, targetAngle, t);
            time += Time.deltaTime;
            yield return null;
        }
        transform.rotation = targetAngle;

        // Debug.Log("Finished at =>  Time: "+ Time.time);

    }

    public IEnumerator RotateFinger(Transform fg, Vector3 angle, float duration)
    {
        // Debug.Log("Started at =>  Time: "+ Time.time);


        Debug.Log(angle);

        Quaternion startAngle = Quaternion.Euler(0f, 0f, 0f);
        Quaternion targetAngle = Quaternion.Euler(angle.x, angle.y, angle.z);

        //time = 0;
        //while (time < duration)
        //{
        //    t = time / duration;
        //    t = Mathf.Sin(t * Mathf.PI * 0.5f);

        //    fg.rotation = Quaternion.Lerp(startAngle, targetAngle, t);
        //    time += Time.deltaTime;
        //    yield return null;
        //}
        fg.rotation = targetAngle;
        yield return null;

        // Debug.Log("Finished at =>  Time: "+ Time.time);

    }

    public IEnumerator CurvedMovementUp(Vector3 target, float duration)
    {
        float frequency = 3.45f;
        float magnitude = .2f;
        float mov_speed = 0.025f;
        float rot_speed = 0.02f;


        Vector3 pos;
        Vector3 axis = new Vector3(0, 1, 0);

        time = 0;
        while (time < duration)
        {
            t = time / duration;

            pos = transform.position + ((target - transform.position) * t * mov_speed);
            pos += axis * (Mathf.Sin(t * frequency) * magnitude) * rot_speed;

            transform.position = pos;
            time += Time.deltaTime;

            yield return null;
        }

        transform.position = target;
    }

    public IEnumerator CurvedMovementDown(Vector3 target, float duration)
    {
        float frequency = 3.45f;
        float magnitude = .2f;
        float mov_speed = 0.025f;
        float rot_speed = 0.02f;


        Vector3 pos;
        Vector3 axis = new Vector3(0, 1, 0);

        time = 0;
        while (time < duration)
        {
            t = time / duration;

            pos = transform.position + ((target - transform.position) * t * mov_speed);
            pos -= axis * (Mathf.Sin(t * frequency) * magnitude) * rot_speed;

            transform.position = pos;
            time += Time.deltaTime;

            yield return null;
        }

        transform.position = target;
    }

    public IEnumerator CurvedMovementRight(Vector3 target, float duration)
    {
        float frequency = 3.45f;
        float magnitude = .2f;
        float mov_speed = 0.025f;
        float rot_speed = 0.02f;


        Vector3 pos;
        Vector3 axis = new Vector3(1, 0, 0);

        time = 0;
        while (time < duration)
        {
            t = time / duration;

            pos = transform.position + ((target - transform.position) * t * mov_speed);
            pos += axis * (Mathf.Sin(t * frequency) * magnitude) * rot_speed;

            transform.position = pos;
            time += Time.deltaTime;

            yield return null;
        }

        transform.position = target;

    }

    public IEnumerator CurvedMovementLeft(Vector3 target, float duration)
    {
        float frequency = 3.45f;
        float magnitude = .2f;
        float mov_speed = 0.025f;
        float rot_speed = 0.02f;


        Vector3 pos;
        Vector3 axis = new Vector3(1, 0, 0);

        time = 0;
        while (time < duration)
        {
            t = time / duration;

            pos = transform.position + ((target - transform.position) * t * mov_speed);
            pos -= axis * (Mathf.Sin(t * frequency) * magnitude) * rot_speed;

            transform.position = pos;
            time += Time.deltaTime;

            yield return null;
        }

        transform.position = target;

    }

    public IEnumerator ZigzagMovement(Vector3 target, float duration)
    {
        float frequency = 13.5f;
        float magnitude = 1f;
        float mov_speed = 0.025f;
        float rot_speed = 0.02f;


        Vector3 pos;
        Vector3 axis = new Vector3(1, 0, 0);

        time = 0;
        while (time < duration)
        {
            t = time / duration;

            // pos = transform.position + ((target - transform.position) * t * mov_speed);
            pos = transform.position;

            pos -= axis * (Mathf.Sin(t * frequency) * magnitude) * rot_speed;

            transform.position = pos;
            time += Time.deltaTime;

            yield return null;
        }

        transform.position = target;
    }

    // public IEnumerator ZigzagMovement(Vector3 target, float duration)
    // {
    //     float frequency = 13.5f;
    //     float magnitude = .2f;
    //     float mov_speed = 0.025f;
    //     float rot_speed = 0.02f;


    //     Vector3 pos;
    //     Vector3 axis = new Vector3(1, 0, 0);

    //     time = 0;
    //     while (time < duration)
    //     {
    //         t = time / duration;

    //         pos = transform.position + ((target - transform.position) * t * mov_speed);
    //         pos -= axis * (Mathf.Sin(t * frequency) * magnitude) * rot_speed;

    //         transform.position = pos;
    //         time += Time.deltaTime;

    //         yield return null;
    //     }

    //     transform.position = target;
    // }
    
    public IEnumerator CircularMovementHorizontal(Vector3 target, float duration)
    {
        float frequency = 3.4f;
        float magnitude = .2f;
        float mov_speed = 0.025f;
        float rot_speed = 0.025f;


        Vector3 pos;
        Vector3 startPos = transform.position;
        Vector3 axis = new Vector3(1, 0, 0);


        time = 0;
        duration = duration / 2;

        while (time < duration)
        {
            t = time / duration;

            pos = transform.position + ((target - transform.position) * t * mov_speed);
            pos -= axis * (Mathf.Sin(t * frequency) * magnitude) * rot_speed;

            transform.position = pos;
            time += Time.deltaTime;

            yield return null;
        }
        Debug.Log(t);

        time = 0;
        while (time < duration)
        {
            t = time / duration;

            pos = transform.position + ((startPos - transform.position) * t * mov_speed);
            pos += axis * (Mathf.Sin(t * frequency) * magnitude) * rot_speed;

            transform.position = pos;
            time += Time.deltaTime;

            yield return null;
        }
        Debug.Log(t);

        transform.position = startPos;


    }


    public IEnumerator CircularMovementVertical(Vector3 target, float duration)
    {
        float frequency = 3.4f;
        float magnitude = .2f;
        float mov_speed = 0.025f;
        float rot_speed = 0.025f;


        Vector3 pos;
        Vector3 startPos = transform.position;
        Vector3 axis = new Vector3(0, 1, 0);


        time = 0;
        duration = duration / 2;

        while (time < duration)
        {
            t = time / duration;

            pos = transform.position + ((target - transform.position) * t * mov_speed);
            pos -= axis * (Mathf.Sin(t * frequency) * magnitude) * rot_speed;

            transform.position = pos;
            time += Time.deltaTime;

            yield return null;
        }
        Debug.Log(t);

        time = 0;
        while (time < duration)
        {
            t = time / duration;

            pos = transform.position + ((startPos - transform.position) * t * mov_speed);
            pos += axis * (Mathf.Sin(t * frequency) * magnitude) * rot_speed;

            transform.position = pos;
            time += Time.deltaTime;

            yield return null;
        }
        Debug.Log(t);

        transform.position = startPos;


    }

}
