using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    public TextMeshProUGUI TimerText;

    public void StartTimer()
    {
        StartCoroutine(Timer_Coroutine());
    }

    private IEnumerator Timer_Coroutine()
    {
        int m = 0;
        int s = 0;

        while (true)
        {
            yield return new WaitForSeconds(1);
            s++;
            
            if (s % 60 == 0)
            {
                m++;
                s = 0;
            }
            TimerText.SetText(m.ToString("D2") + ":" + s.ToString("D2"));
        }
    }

    public void PauseTimer()
    {
        StopAllCoroutines();
    }
}
