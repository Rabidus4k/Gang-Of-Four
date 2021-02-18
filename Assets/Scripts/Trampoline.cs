using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour, IActionAble
{
    public Action SomeAction { get; set; }

    public Vector2 Direction;
    public float ForceAmmount;

    private Animator _animator;
    private PlayerMovement _playerMovement;
    private void Awake()
    {
        _playerMovement = FindObjectOfType<PlayerMovement>();
        _animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        SomeAction += Jump;
    }

    private void OnDisable()
    {
        SomeAction -= Jump;
    }

    private void Jump()
    {
        StartCoroutine(Jump_Coroutine());
        
    }

    private IEnumerator Jump_Coroutine()
    {
        _animator.SetBool("Jump", true);
        _playerMovement.AddForce(Direction, ForceAmmount);
        yield return new WaitForSeconds(0.1f);
        _animator.SetBool("Jump", false);
    }
}
