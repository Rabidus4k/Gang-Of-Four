using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ability : MonoBehaviour
{
    public int ID;

    public static Ability SelectedAbility;
    public Image SelectImage;
    public Image ReloadBar;

    public GameObject LockImage;
    public GameObject ClockImage;

    public bool IsSelected;
    public bool IsLocket = true;
    public bool IsReloading;
    public float ReloadTime;

    public void StartReload()
    {
        StartCoroutine(StartReload_Coroutine());
    }

    public void Unlock()
    {
        ReloadBar.fillAmount = 0;
        IsLocket = false;
        LockImage.SetActive(false);
        Select();
    }

    public void Select()
    {
        if (null != SelectedAbility)
        {
            SelectedAbility.Deselect();
        }
        SelectedAbility = this;
        IsSelected = true;
        SelectImage.enabled = true;
    }

    public void Deselect()
    {
        SelectImage.enabled = false;
        IsSelected = false;
    }

    private IEnumerator StartReload_Coroutine()
    {
        ReloadBar.fillAmount = 1;
        ClockImage.SetActive(true);
        while (ReloadBar.fillAmount > 0)
        {
            yield return new WaitForSeconds(ReloadTime);
            IsReloading = true;
            ReloadBar.fillAmount -= 0.1f;
        }
        ClockImage.SetActive(false);
        IsReloading = false;
    }
}
