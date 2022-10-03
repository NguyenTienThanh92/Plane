using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject Menu;
    public GameObject Plane1;
    public GameObject Plane2;
    public GameObject Plane3;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

   
    public void Player1()
    {
        Plane1.SetActive(true);
        Menu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Player2()
    {
        Plane2.SetActive(true);
        Menu.SetActive(false);
        Time.timeScale = 1;
    }
    public void Player3()
    {
        Plane3.SetActive(true);
        Menu.SetActive(false);
        Time.timeScale = 1;
    }
}
