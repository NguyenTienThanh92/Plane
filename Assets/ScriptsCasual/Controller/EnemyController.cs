using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;
using DG.Tweening;

public class EnemyController : MoveController

{
    private float time = 0;
    public GameObject smoke;
    public GameObject bullet;
    public Transform transhoot;
    public float hp;
    public float damage;
    void Start()
    {
        EnemyRotation();
    }

    // Update is called once per frame
    void Update()
    {
        AutoShoot();
        base.Move(transform.up);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BulletPlayer"))
        {
            if (hp <= 0)
            {
                Destroy(this.gameObject);
                SoundController.instance.SoundExplosion();
                Observer.Instance.Notify(TOPICNAME.ENEMYDESTROY);
            }
            else
            {
                var objectCollisions = collision.GetComponent<BulletController>();
                hp = objectCollisions.CalculateHp(hp);
            }
        }
        if (collision.gameObject.CompareTag("Rocket"))
        {
            Destroy(this.gameObject);
            SoundController.instance.SoundExplosion();
            Observer.Instance.Notify(TOPICNAME.ENEMYDESTROY);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            SoundController.instance.SoundExplosion();
            // Instantiate(smoke, this.gameObject.transform.position, this.gameObject.transform.rotation);
            //Observer.Instance.Notify(TOPICNAME.ENEMYCOLLISION);
        }
        if (collision.gameObject.CompareTag("Shield"))
        {
            Destroy(this.gameObject);
            Instantiate(smoke, this.gameObject.transform.position, this.gameObject.transform.rotation);
            SoundController.instance.SoundExplosion();
        }
        if (collision.gameObject.CompareTag("DeathZone"))
        {
            Destroy(this.gameObject);
        }
    }

    public void EnemyRotation()
    {
        transform.DORotate(new Vector3(0, 0, 180), 0f);
    }

    public void AutoShoot()
    {
        time += Time.deltaTime;
        if (time >= 2)
        {
            Shoot();
            
            time = 0;
        }
    }

    public void Shoot()
    {
        Instantiate(bullet, transhoot.position, transhoot.rotation);
    }
    public virtual float CalculateHp(float hpPlayer)
    {
        var hpLeft = hpPlayer - damage;
        return hpLeft;
    }
}
    
