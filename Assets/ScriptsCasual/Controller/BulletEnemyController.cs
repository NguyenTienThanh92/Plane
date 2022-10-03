using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BulletEnemyController : BulletController
{
    void Update()
    {
        //base.MoveDown(-transform.up);
        Move(this.transform.up);
        BulletEx();
        
    }
    //public void BulletRotation()
    //{
    //    transform.DORotate(new Vector3(0, 0, 180), 0f);
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            Instantiate(smoke, this.gameObject.transform.position, this.gameObject.transform.rotation);
        }
        if ( collision.gameObject.CompareTag("Shield"))
        {
            Destroy(this.gameObject);
            Instantiate(smoke, this.gameObject.transform.position, this.gameObject.transform.rotation);
        }
        if (collision.gameObject.CompareTag("DeathZone"))
        {
            Destroy(this.gameObject);
        }
    }
   
}
