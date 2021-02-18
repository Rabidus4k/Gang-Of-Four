using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ApplesCounter : MonoBehaviour
{
    public TextMeshProUGUI ApplesCountText;

    private PlayerCollection _playerCollection;
    private int _counter = 0;

    private void Awake()
    {
        _playerCollection = FindObjectOfType<PlayerCollection>();
        ApplesCountText.SetText("0 / 20");
    }

    private void OnEnable()
    {
        _playerCollection.CollectedApples += EncreaseApples;
    }

    private void OnDisable()
    {
        _playerCollection.CollectedApples -= EncreaseApples;
    }

    private void EncreaseApples()
    {
        _counter++;
        SoundsController.inst.Play("Apple");
        ApplesCountText.SetText(_counter.ToString() + " / 20");
    }
}
