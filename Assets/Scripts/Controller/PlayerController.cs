using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public BulletController bullet;
    public Transform transhoot;
    public float time = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    public void Shoot()
    {
        Instantiate(bullet, transhoot.position, transhoot.rotation);
    }
}
