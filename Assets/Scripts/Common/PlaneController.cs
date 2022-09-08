using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;

public class PlaneController : MoveController
{
    public BulletController bullet;
    public Transform transhoot;
    public float hp;
    public float level;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public BulletController CreatBullet(Transform transhoot)
    //{
       // BulletController bulletclone = PoolingObject.createPooling<BulletController>(bullet);
       // if (bulletclone == null)
       // {
      //      return Instantiate(bullet, transhoot.position, transhoot.rotation);
      //  }
      //  bulletclone.time = 0;
      //  bulletclone.transform.position = transhoot.position;
      //  bulletclone.transform.rotation = transhoot.rotation;
      //  bulletclone.tag = this.tag;
      // / return bulletclone;
   // }
}
