using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    [Range(0, 100)]
    public float _speed;

    [SerializeField]
    [Range(0, 100)]
    private float _jumpSpeed = 10;

    private Animator _playerAnimator;
    private SpriteRenderer _spriteRenderer;

    private bool _isGrounded = true;
    private bool _doubleJump = true;
    [SerializeField]
    private LayerMask _layerMaskWalls;

    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _isGrounded = true;
        _doubleJump = true;
    }

    private void Update()
    {
        _rigidbody2D.velocity = new Vector2(0, _rigidbody2D.velocity.y);


        var input = Input.GetAxis("Horizontal");
        if (Math.Abs(input) > 0)
        {
            if (input < 0)
                _spriteRenderer.flipX = true;
            else
                _spriteRenderer.flipX = false;

            _rigidbody2D.velocity = new Vector2(input * _speed, _rigidbody2D.velocity.y);
        }

        if (Input.GetButtonDown("Jump") && (_isGrounded || _doubleJump))
        {
            if (_isGrounded == false)
            {
                _doubleJump = false;
                AddForce(Vector2.up, _jumpSpeed + 2);
                Instantiate(Container.inst.DestroyParticles, gameObject.transform.position, Quaternion.identity);
            } 
            else
                AddForce(Vector2.up, _jumpSpeed);

            _isGrounded = false;
        }

        _playerAnimator.SetFloat("X", Math.Abs(_rigidbody2D.velocity.x));
        _playerAnimator.SetFloat("Y", _rigidbody2D.velocity.y);
    }

    public void AddForce(Vector2 dir, float ammout)
    {
        SoundsController.inst.Play("Jump");
        _rigidbody2D.velocity = new Vector2(0, 0);
        _rigidbody2D.AddForce(dir * ammout, ForceMode2D.Impulse);
    }
}
