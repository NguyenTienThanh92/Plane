using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;

public class BulletController : MoveController

{
    private float time = 0;
    public GameObject smoke;
    public float timeLimit;
   

    void Update()
    {
        BulletEx();
        Move(this.transform.up);
    }
    protected virtual void BulletEx()
    {
        if ( time == timeLimit)
        {
            Destroy(this.gameObject);
            Instantiate(smoke, this.gameObject.transform.position, this.gameObject.transform.rotation);
        }
        time++;
    }   
}
