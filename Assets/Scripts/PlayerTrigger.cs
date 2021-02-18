using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    private GameObject Info;

    private GameObject _collisionObject;

    private bool _inTrigger = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!gameObject.CompareTag("Player"))
            return;

        if (collision.gameObject.CompareTag("Trigger") && !_inTrigger)
        {      
            Info = Instantiate(Container.inst.InfoPrefab, transform);
            _collisionObject = collision.gameObject;
            _collisionObject.GetComponent<TriggerInfo>().ShowInfo();
            _inTrigger = true;
        }

        if (collision.gameObject.CompareTag("Killer") && !_inTrigger)
        {
            Info = Instantiate(Container.inst.InfoPrefab, transform);
            _collisionObject = collision.gameObject;
            _collisionObject.GetComponent<TriggerInfo>().ShowInfo();
            _collisionObject.GetComponent<IActionAble>().SomeAction.Invoke();
            _inTrigger = true;
        }

        if (collision.gameObject.CompareTag("Trampoline") && !_inTrigger && gameObject.transform.localScale.x < 1.9f)
        {
            _collisionObject = collision.gameObject;
            _collisionObject.GetComponent<IActionAble>().SomeAction.Invoke();
            _inTrigger = true;
        }

        if (collision.gameObject.CompareTag("Friend") && !_inTrigger)
        {
            _inTrigger = true;
            collision.gameObject.GetComponent<FriendController>().UplockAbility();
            gameObject.transform.localScale += Vector3.one * 0.33f;
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DestroyWall") && gameObject.transform.localScale.x > 1.9f)
        {
            SoundsController.inst.Play("Break");
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_inTrigger)
        {
            _inTrigger = false;
            _collisionObject = null;

            if (null != Info)
                Destroy(Info);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && null != _collisionObject)
        {
            _collisionObject.GetComponent<IActionAble>().SomeAction.Invoke();
        }
    }
}
