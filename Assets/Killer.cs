using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killer : TriggerInfo, IActionAble
{
    public float X;
    public float Y;

    private DeathCounter _deathCounter;
    private PlayerMovement _playerMovement;

    private void Awake()
    {
        _playerMovement = FindObjectOfType<PlayerMovement>();
        _deathCounter = FindObjectOfType<DeathCounter>();
    }

    public Action SomeAction { get; set; }

    private void OnEnable()
    {
        SomeAction += Teleport;
    }

    private void OnDisable()
    {
        SomeAction -= Teleport;
    }
    public void Teleport()
    {
        SoundsController.inst.Play("Damage");
        _playerMovement.transform.position = new Vector2(X, Y);
        _deathCounter.Die();
    }
}
