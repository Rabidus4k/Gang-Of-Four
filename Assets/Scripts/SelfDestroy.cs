using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    public float Timer = 0.2f;

    private void Start()
    {
        Destroy(gameObject, Timer);
    }
}
