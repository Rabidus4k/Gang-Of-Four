using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TransitionController : MonoBehaviour
{
    public RectTransform BlackImage;

    public void Transit(System.Action action)
    {
        StartCoroutine(Transit_Coroutine(action));
    }
    private IEnumerator Transit_Coroutine(System.Action action)
    {
        var time = 1.5f;
        LeanTween.alpha(BlackImage, 1, time).setLoopPingPong(1);
        yield return new WaitForSeconds(time);
        action.Invoke();
    }
}
