using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LTAUnityBase.Base.DesignPattern;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int scorePlayer;
    public Text scoreTxt;
    private int scoreCount;
    public GameObject rocket;
    public Button shootRocket;
    public Transform transhoot;
    public Transform transhoot1;
    public Transform transhoot2;
    public Transform transhoot3;
    public GameObject panelOver;
    public GameObject panelWingame;
    public GameObject panelPause;
    public GameObject panelSetting;
    public GameObject boss;
    public GameObject gateEnemy;
    public bool gunAOE, updateBullet;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        Observer.Instance.AddObserver(TOPICNAME.ENEMYDESTROY, AddScore);
        Observer.Instance.AddObserver(TOPICNAME.METEORITEDESTROY, AddScoreMeteorite);
        //Observer.Instance.AddObserver(TOPICNAME.METEORITECOLISION, MeteoriteColision);
        //Observer.Instance.AddObserver(TOPICNAME.ENEMYCOLLISION, EnemyColision);
    }
    private void Start()
    {
        StartCoroutine(UpdateScore());
    }

    // Update is called once per frame
    void Update()
    {
        //scoreTxt.text = "Score : " + scorePlayer.ToString();
        ScoreCount();
    }

    public void AddScore(object data)
    {
        scorePlayer += 10;
    }


    public void ScoreCount()
    {
        {
            if (scorePlayer % 30 == 0 && !(scorePlayer % 40 == 0))
            {
                // PlayerController.instance.GunAOEActive();
                gunAOE = true;
                updateBullet = false;
                GunController.instance.bulletCheck = false;
            }
            
            if (scorePlayer % 40 == 0 && !(scorePlayer % 30 == 0))
            {
                gunAOE = false;
                updateBullet = true;
                GunAOEController.instance.bulletCheck = false;
            }
            
            if (scorePlayer % 30 == 0 && scorePlayer % 40 == 0 && scorePlayer != 0)
            {
                //var i = Random.Range(0, 2);
                //if ( i == 0)
                //{
                    //gunAOE = true;
                //    updateBullet = false;
              //  }
              //  else
              //  {
                    gunAOE = false;
                    updateBullet = true;
               // }
            }         
        }
    }

    public void AddScoreMeteorite(object data)
    {
        scorePlayer += 5;
    }
    //public void MeteoriteColision(object data)
    //{
    //    if (scorePlayer < 20)
    //    {
    //        scorePlayer = 0;
    //    }
    //    else
    //    {
    //        scorePlayer -= 20;
    //    }
    //}
    //public void EnemyColision(object data)
    //{
    //    if (scorePlayer < 10)
    //    {
    //        scorePlayer = 0;
    //    }
    //    else
    //    {
    //        scorePlayer -= 10;
    //    }
    //}
    public void ShootRocket()
    {
        Instantiate(rocket, transhoot.position, transhoot.rotation);
        Instantiate(rocket, transhoot1.position, transhoot1.rotation);
        Instantiate(rocket, transhoot2.position, transhoot2.rotation);
        Instantiate(rocket, transhoot3.position, transhoot3.rotation);
        shootRocket.interactable = false;
        DOVirtual.DelayedCall(30f, delegate
        {
            shootRocket.interactable = true;
        });
    }
    public void EndGame()
    {
        panelOver.SetActive(true);
        Time.timeScale = 0;
    }

    public void WinGame()
    {
        panelWingame.SetActive(true);
        Time.timeScale = 0;
    }
    public void Pause()
    {
        Time.timeScale = 0;
        panelPause.SetActive(true);
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }
    public void Play()
    {
        Time.timeScale = 1;
        panelPause.SetActive(false);
    }
    public void Setting()
    {
        panelSetting.SetActive(true);
    }
    public void Exit()
    {
        panelSetting.SetActive(false);
    }
    private IEnumerator UpdateScore()
    {
        while (scorePlayer <= 1000)
        {
            scoreTxt.text = "Score : " + scorePlayer.ToString();
            yield return null;
        }
        gateEnemy.SetActive(false);
        boss.SetActive(true);
    }

}