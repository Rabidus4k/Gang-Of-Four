using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public AudioClip Clip;
    public float Volume;
    public float Pitch;
    public string Name;

    public bool Loop;
    [HideInInspector] public AudioSource Source;
}
