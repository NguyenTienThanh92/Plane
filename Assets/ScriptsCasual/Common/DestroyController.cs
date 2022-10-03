using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyController : MonoBehaviour
{

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.gameObject.CompareTag("DeathZone"))
        {
            Destroy(this.gameObject);
        }
        if ( collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
