using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float Speed = 2f;

    void FixedUpdate()
    {
        transform.Rotate(0,0, Speed);
    }
}
