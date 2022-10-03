using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using LTAUnityBase.Base.DesignPattern;

public class BulletPlayerController : BulletController
{
    void Update()
    {
        base.Move(transform.up);
        BulletEx();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
            Instantiate(smoke, this.gameObject.transform.position, this.gameObject.transform.rotation);
        }
        if  (collision.gameObject.CompareTag("Meteorite"))
        {
            Destroy(this.gameObject);
            Instantiate(smoke, this.gameObject.transform.position, this.gameObject.transform.rotation);
        }
        if (collision.gameObject.CompareTag("Boss"))
        {
            Destroy(this.gameObject);
            Instantiate(smoke, this.transform.position, this.transform.rotation);
        }
    }
    
}
