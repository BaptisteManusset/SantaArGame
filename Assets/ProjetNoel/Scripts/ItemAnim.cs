using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAnim : MonoBehaviour
{
    private Vector3 pointA;
    private Vector3 pointB;
    private float speed = .3f;
    private float RotationSpeed = 50f;
    private float offset = .1f;

    private float t;

    private void Start()
    {
        pointA += transform.position - Vector3.up * offset;
        pointB += transform.position - Vector3.down * offset;
    }

    private void Update()
    {
        t += Time.deltaTime * speed;

        // Moves the object to target position
        transform.position = Vector3.Lerp(pointA, pointB, t);

        // Flip the points once it has reached the target
        if (t >= 1)
        {
            var b = pointB;
            var a = pointA;

            pointA = b;
            pointB = a;

            t = 0;
        }

        transform.Rotate(Vector3.up * (RotationSpeed * Time.deltaTime));
    }

    // What Linear interpolation actually looks like in terms of code
    private Vector3 CustomLerp(Vector3 a, Vector3 b, float t)
    {
        return a * (1 - t) + b * t;
    }
}
