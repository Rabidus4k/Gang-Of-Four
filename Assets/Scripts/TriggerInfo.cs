using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInfo : MonoBehaviour
{
    public string Info;

    public void ShowInfo()
    {
        DialogueMenager.inst.ShowDialogue(Info);
    }

    public void HideInfo()
    {
        DialogueMenager.inst.HideDialogue();
    }
}
