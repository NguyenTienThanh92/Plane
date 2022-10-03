using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MoveController
{
    public GameObject bullet;
    public Transform transhoot;
    public float hp;

    protected virtual void Shoot()
    {
        Instantiate(bullet, transhoot.position, transhoot.rotation);
    }
}

   

    //public BulletController CreatBullet(Transform transhoot)
    //{
       // BulletController bulletclone = PoolingObject.createPooling<BulletController>(bullet);
      //  if (bulletclone == null)
       // {
      //      return Instantiate(bullet, transhoot.position, transhoot.rotation);
       // }
      //  bulletclone.time = 0;
      //  bulletclone.transform.position = transhoot.position;
      //  bulletclone.transform.rotation = transhoot.rotation;
      //  bulletclone.tag = this.tag;
      //  return bulletclone;
 //  }

