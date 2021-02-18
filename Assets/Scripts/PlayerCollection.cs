using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollection : MonoBehaviour
{
    public event Action CollectedApples;

    private bool _collecting = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectable") && !_collecting)
        {
            _collecting = true;
            CollectedApples.Invoke();
            Instantiate(Container.inst.DestroyParticles, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectable") && _collecting)
        {
            _collecting = false;
        }
    }
}
