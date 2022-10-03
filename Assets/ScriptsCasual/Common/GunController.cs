using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GunController : MonoBehaviour
{
    public float time;
    public GameObject[] bullet;
    public GameObject gun;
    public Transform transhoot;
    public static GunController instance;
    private int _bulletIndex = 0;
    public bool bulletCheck;
    //public Animator animatorFire;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        //animatorFire = false;
    }

    void Update()
    {
        AutoShoot();

        if (bulletCheck)
            return;
        if (GameManager.instance.updateBullet)
        {
            BulletCount();
            bulletCheck = true;
        }
    }

    public void AutoShoot()
    {
        time += Time.deltaTime;
        if (time >= 0.5f)
        {
            Shoot();
            time = 0;
        }
    }

    public void Shoot()
    {
        Instantiate(bullet[_bulletIndex], transhoot.position, transhoot.rotation);
        //TranshootController.instance.PlayAnimator();
 //        TranshootController.instance.checkAnimator = true;
 //        DOVirtual.DelayedCall(0.3f, delegate {
 //            TranshootController.instance.checkAnimator = false;
	//});
        
            
           // Instantiate(fireEffect, transhoot.position, transhoot.rotation);
    }

    //private IEnumerator Shoot()
    //{
    //    while (true)
    //    {
    //        Instantiate(bullet[_bulletIndex], transhoot.position, transhoot.rotation);
    //        Instantiate(fireEffect, transhoot.position, transhoot.rotation);
    //        yield return new WaitForSeconds(time);
    //    }
    //}
   
        
    public void BulletCount()
    {
        _bulletIndex ++;
        if (_bulletIndex >= bullet.Length)

            _bulletIndex = bullet.Length -1;
    }
}
