using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;

public class BulletController : MoveController

{
    private float time;
    public float damage;
    public GameObject smoke;

    protected virtual void BulletEx()
    {
        time += Time.deltaTime;
        if ( time >= 1.2f)
        {
        Destroy(this.gameObject);
        Instantiate(smoke, this.gameObject.transform.position, this.gameObject.transform.rotation);
        }
       // DOVirtual.DelayedCall(time, delegate
       // {
       //     Destroy(this.gameObject);
       //     Instantiate(smoke, this.gameObject.transform.position, this.gameObject.transform.rotation);
        //});
    }
    public virtual float CalculateHp(float hp)
    {
        var hpLeft = hp - damage;
        return hpLeft;
    }
}
