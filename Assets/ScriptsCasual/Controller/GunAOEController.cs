using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAOEController : MonoBehaviour
{
    public Vector3 angle;
    public GameObject [] bullet;
    public Transform transhoot;
    //public GameObject fireEffect;
    public float time = 0;
    private int _bulletIndex = 0;
    public bool bulletCheck;
    public static GunAOEController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Update()
    {
        AutoShoot();
        if (bulletCheck)
            return;
        if (GameManager.instance.gunAOE)
        {
            BulletCount();
            bulletCheck = true;
        }
    }

    public void AOEShoot()
    {
        Instantiate(bullet[_bulletIndex], transhoot.position, Quaternion.identity);
        Instantiate(bullet[_bulletIndex], transhoot.position, Quaternion.Euler(angle.x, angle.y, 20));
        Instantiate(bullet[_bulletIndex], transhoot.position, Quaternion.Euler(angle.x, angle.y, -20));
        Instantiate(bullet[_bulletIndex], transhoot.position, Quaternion.Euler(angle.x, angle.y, 10));
        Instantiate(bullet[_bulletIndex], transhoot.position, Quaternion.Euler(angle.x, angle.y, -10));
       // Instantiate(fireEffect, transhoot.position, transhoot.rotation);

    }
    public void AutoShoot()
    {
        time += Time.deltaTime;
        if (time >= 0.8f)
        {
            AOEShoot();
            time = 0;
        }
    }
    //private IEnumerator AOEShoot()
    //{
    //    while(true)
    //    {
    //        Instantiate(bullet[_bulletIndex], transhoot.position, Quaternion.identity);
    //        Instantiate(bullet[_bulletIndex], transhoot.position, Quaternion.Euler(angle.x, angle.y,20));
    //        Instantiate(bullet[_bulletIndex], transhoot.position, Quaternion.Euler(angle.x, angle.y, -20));
    //        Instantiate(bullet[_bulletIndex], transhoot.position, Quaternion.Euler(angle.x, angle.y, 10));
    //        Instantiate(bullet[_bulletIndex], transhoot.position, Quaternion.Euler(angle.x, angle.y, -10));
    //        Instantiate(fireEffect, transhoot.position, transhoot.rotation);
    //        yield return new WaitForSeconds(time);
    //    }
    //}

    public void BulletCount()
    {
        _bulletIndex++;
        if (_bulletIndex >= bullet.Length)

            _bulletIndex = bullet.Length - 1;
    }
}
