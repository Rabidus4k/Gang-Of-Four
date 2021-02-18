using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : TriggerInfo, IActionAble
{
    public float X;
    public float Y;

    public bool IsStart = false;
    public bool IsFinish = false;

    private PlayerMovement _playerMovement;
    private TransitionController _transitionController;

    private void Awake()
    {
        _playerMovement = FindObjectOfType<PlayerMovement>();
        _transitionController = FindObjectOfType<TransitionController>();
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
        _transitionController.Transit(Action);
    }
    
    public void Action()
    {
        _playerMovement.transform.position = new Vector2(X, Y);
        if (IsStart)
            FindObjectOfType<Timer>().StartTimer();
        if (IsFinish)
        {
            FindObjectOfType<Timer>().PauseTimer();
            _playerMovement.gameObject.transform.localScale = Vector3.one;
        }
    }
}
