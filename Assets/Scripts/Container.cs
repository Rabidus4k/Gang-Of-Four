using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    public static Container inst;

    public GameObject DisappearParticles;
    public GameObject AppearParticles;
    public GameObject DestroyParticles;
    public GameObject InfoPrefab;

    private void Awake()
    {
        if (null != inst)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            inst = this;
        }
    }
}
