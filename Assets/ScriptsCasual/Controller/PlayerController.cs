using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using LTAUnityBase.Base.DesignPattern;

public class PlayerController : MonoBehaviour
{ 
    public Slider slider_hp;
    public float hp;
    public GameObject shield;
    public GameObject supportShip;
    public GameObject gunBonus;
    public GameObject gunAOE;
    public GameObject gun;
    public GameObject smoke;
    private bool shieldActive;
    public static PlayerController instance;
    private Camera _mainCamera;
    private float _HorizontalBound;
    private float _verticalBound;
    public float borderGap;


    // public GameObject bullet2;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        {
            slider_hp.maxValue = hp;
        }
        _mainCamera = Camera.main;

    }

    private void Start()
    {
    var screenBound = _mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, _mainCamera.transform.position.z));
       _HorizontalBound = screenBound.x;
       _verticalBound = screenBound.y;
    }

    // Update is called once per frame
    void Update()
    {
        slider_hp.value = hp;
        PlayerDestroy();
        if(GameManager.instance.gunAOE)
        {
            GunAOEActive();
        }
        else
        {
            GunActive();
        }
    }

   
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BulletEnemy" && shieldActive == false)
        {
            var objectCollisions = collision.GetComponent<BulletController>();
            hp = objectCollisions.CalculateHp(hp);
        }
        if (collision.gameObject.tag == "Meteorite" && shieldActive == false)
        {
            var objectCollision = collision.GetComponent<MeteoriteController>();
            hp = objectCollision.CalculateHp(hp);
            Instantiate(smoke, collision.transform.position, collision.transform.rotation);
        }
        if (collision.gameObject.tag == "Enemy" && shieldActive == false)
        {
            var objectCollision = collision.GetComponent<EnemyController>();
            hp = objectCollision.CalculateHp(hp);
            Instantiate(smoke, collision.transform.position, collision.transform.rotation);
        }
        if (collision.gameObject.tag == "Boss")
        {
            var objectCollision = collision.GetComponent<BossController>();
            hp = objectCollision.CalculateHp(hp);
        }

        if (collision.gameObject.tag == "ItemHP")
        {
            if (hp <= 200 && hp >= 170)
            {
                hp = 200;
            }
            else
            {
                hp += 30;
            }
        }
        if (collision.gameObject.tag == "ItemDoubleGun")
        {
            gunBonus.SetActive(true);
            DOVirtual.DelayedCall(15f, delegate
            {
                gunBonus.SetActive(false);
            });

        }
        if (collision.gameObject.tag == "ItemShield")
        {
            shield.SetActive(true);
            shieldActive = true;
            DOVirtual.DelayedCall(15f, delegate
            {
                shield.SetActive(false);
                shieldActive = false;
            });
        }
        if (collision.gameObject.tag == "ItemSupporters")
        {
            supportShip.SetActive(true);
            DOVirtual.DelayedCall(10f, delegate
            {
                supportShip.SetActive(false);
            });
        }
        //if (collision.gameObject.tag == "ItemWing")
        //{
        //    wing.SetActive(true);
        //    DOVirtual.DelayedCall(10f, delegate
        //    {
        //        wing.SetActive(false);
        //    });
        //}
        if (collision.gameObject.tag == "ItemPromax")
        {
            if (hp <= 200 && hp >= 170)
            {
                hp = 200;
            }
            else
            {
                hp += 30;
            }
            gunBonus.SetActive(true);
            DOVirtual.DelayedCall(15f, delegate
            {
                gunBonus.SetActive(false);
            });
            shield.SetActive(true);
            shieldActive = true;
            DOVirtual.DelayedCall(15f, delegate
            {
                shield.SetActive(false);
                shieldActive = false;
            });
            supportShip.SetActive(true);
            DOVirtual.DelayedCall(10f, delegate
            {
                supportShip.SetActive(false);
            });
            //wing.SetActive(true);
            //DOVirtual.DelayedCall(10f, delegate
            //{
            //    wing.SetActive(false);
            //});
        }
    }
    public void PlayerDestroy()
    {
        if (hp <= 0)
        {
            GameManager.instance.EndGame();
        }
    }

    public void GunAOEActive()
    {
        gunAOE.SetActive(true);
        gun.SetActive(false);
    }

    public void GunActive()
    {
        gun.SetActive(true);
        gunAOE.SetActive(false);
    }
    
    private void LateUpdate() // keep the object inside the screen
    {
        var viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, _HorizontalBound * -1 + borderGap, _HorizontalBound - borderGap);
        viewPos.y = Mathf.Clamp(viewPos.y, _verticalBound * -1 + borderGap, _verticalBound - borderGap);
        transform.position = viewPos;
        //var viewPos = transform.position;
        //viewPos.x = Mathf.Clamp(viewPos.x, -324f, -319f);
        //transform.position = viewPos;
    }
}
