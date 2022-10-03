using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;

public class MeteoriteController : DestroyController
{
    public float damage;
   
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BulletPlayer"))
        {
            Destroy(this.gameObject);
            SoundController.instance.SoundExplosion();
            Observer.Instance.Notify(TOPICNAME.METEORITEDESTROY);
        }
        if (collision.gameObject.CompareTag("Rocket"))
        {
            Destroy(this.gameObject);
            SoundController.instance.SoundExplosion();
            Observer.Instance.Notify(TOPICNAME.METEORITEDESTROY);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            SoundController.instance.SoundExplosion();
            //Instantiate(smoke, this.transform.position, this.transform.rotation);
            //Observer.Instance.Notify(TOPICNAME.METEORITECOLISION);
        }
        base.OnTriggerEnter2D(collision);
    }
    public virtual float CalculateHp(float hpPlayer)
    {
        var hpLeft = hpPlayer - damage;
        return hpLeft;
    }

}
