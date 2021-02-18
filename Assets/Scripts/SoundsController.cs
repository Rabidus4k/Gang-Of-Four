using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsController : MonoBehaviour
{
    public static SoundsController inst;
    public Sound[] Sounds;
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

        foreach (var sound in Sounds)
        {
            sound.Source = gameObject.AddComponent<AudioSource>();
            sound.Source.clip = sound.Clip;
            sound.Source.volume = sound.Volume;
            sound.Source.pitch = sound.Pitch;
            sound.Source.loop = sound.Loop;
        }

        Play("Music");
    }

    public void Play(string name)
    {
        var s = Array.Find(Sounds, sound => sound.Name == name);
        s.Source.Play();
    }

    public void ChangePitch(string name, float newValue)
    {
        var s = Array.Find(Sounds, sound => sound.Name == name);
        s.Source.pitch = newValue;
    }
}
