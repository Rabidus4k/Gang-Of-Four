using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DeathCounter : MonoBehaviour
{
    public TextMeshProUGUI DeathCounterText;

    private int _deathCount = 0;

    public void Die()
    {
        _deathCount++;
        DeathCounterText.SetText(_deathCount.ToString());
    }
}
