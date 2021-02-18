using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiesController : MonoBehaviour
{
    public Ability[] AbilitiesUI;

    private int _selectedAbilityIndex = 0;

    private SpriteRenderer _spriteRenderer;
    private PlayerMovement _playerMovement;
    private Rigidbody2D _rigidbody2D;
    public float TeleportDistance = 100;

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Fast()
    {
        StartCoroutine(Fast_Coroutine());
    }

    public void Teleport()
    {
        StartCoroutine(Teleport_Coroutine());
    }

    private void Slowmo()
    {
        StartCoroutine(Slowmo_Coroutine());
    }

    private IEnumerator Teleport_Coroutine() 
    {
        var dir = _spriteRenderer.flipX ? Vector3.left : Vector3.right;

        Instantiate(Container.inst.AppearParticles,transform.position,Quaternion.identity);
        _rigidbody2D.MovePosition(transform.position + dir * TeleportDistance);
        SoundsController.inst.Play("Poof");
        yield return new WaitForSeconds(0.1f);
        Instantiate(Container.inst.DisappearParticles, transform.position, Quaternion.identity);
        yield return null;
    }

    private IEnumerator Fast_Coroutine()
    {
        _playerMovement._speed = 20;
        SoundsController.inst.ChangePitch("Music", 1.5f);
        yield return new WaitForSecondsRealtime(4f);
        _playerMovement._speed = 14;
        SoundsController.inst.ChangePitch("Music", 1f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (null != Ability.SelectedAbility)
            {
                if (!Ability.SelectedAbility.IsReloading)
                {
                    Ability.SelectedAbility.StartReload();

                    switch (Ability.SelectedAbility.ID)
                    {
                        case 0:
                            {
                                Fast();
                            }
                            break;
                        case 1:
                            {
                                Teleport();
                            }
                            break;
                        case 2:
                            {
                                Slowmo();
                            }
                            break;
                    }
                }  
            }
            else
            {
                DialogueMenager.inst.ShowDialogue("No ability seems to be unlocked...");
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (!AbilitiesUI[0].IsLocket)
                AbilitiesUI[0].Select();
            else
                DialogueMenager.inst.ShowDialogue("Ability is locked");
        }        
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (!AbilitiesUI[1].IsLocket)
                AbilitiesUI[1].Select();
            else
                DialogueMenager.inst.ShowDialogue("Ability is locked");
        }        
        
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (!AbilitiesUI[2].IsLocket)
                AbilitiesUI[2].Select();
            else
                DialogueMenager.inst.ShowDialogue("Ability is locked");
        }
    }



    private IEnumerator Slowmo_Coroutine()
    {
        Time.timeScale = 0.5f;
        SoundsController.inst.ChangePitch("Music", 0.5f);
        yield return new WaitForSecondsRealtime(4f);
        Time.timeScale = 1f;
        SoundsController.inst.ChangePitch("Music", 1f);
    }
}
