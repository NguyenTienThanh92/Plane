using System.Collections;
using System.Collections.Generic;
using LTAUnityBase.Base.DesignPattern;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject bullet;
    public Transform gun1;
    public Transform gun2;
    public Transform transhoot1;
    public Transform transhoot2;
    public GameObject smoke;
    //public GameObject flashEffect;
    private float time = 0;
    public float hp;
    public float damage;
    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        AutoShoot();
        //var player = PlayerController.instance.gameObject.transform;
        Vector3 direction = player.transform.position;
        var gunDirection = direction - transform.position;
        RotateGun(gunDirection);
    }

    private void RotateGun(Vector3 direction)
    {
        gun1.up = direction;
        gun2.up = direction;
    }
    public void Shoot()
    {
        Instantiate(bullet, transhoot1.position, transhoot1.rotation);
       // Instantiate(flashEffect, transhoot1.position, transhoot1.rotation);
        Instantiate(bullet, transhoot2.position, transhoot2.rotation);
       // Instantiate(flashEffect, transhoot2.position, transhoot2.rotation);
    }
    public void AutoShoot()
    {
        time += Time.deltaTime;
        if (time >= 1.5f)
        {
            Shoot();
            time = 0;
        }
    }

    public float CalculateHp(float hpPlayer)
    {
        var hpLeft = hpPlayer - damage;
        return hpLeft;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BulletPlayer"))
        {
            if (hp <= 0)
            {
                Destroy(this.gameObject);
                Instantiate(smoke, this.transform.position, this.transform.rotation);
                GameManager.instance.WinGame();
                SoundController.instance.SoundExplosion();
            }
            else
            {
                var objectCollisions = collision.GetComponent<BulletController>();
                hp = objectCollisions.CalculateHp(hp);
            }
        }
        if (collision.gameObject.CompareTag("Rocket"))
        {
            var objectCollisions = collision.GetComponent<BulletPlayerController>();
            hp = objectCollisions.CalculateHp(hp);
            SoundController.instance.SoundExplosion();
        } 
    }
    
}