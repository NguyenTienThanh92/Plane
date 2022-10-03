using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;

public class BackGroundController : MonoBehaviour
{
    public static BackGroundController instance;
    [SerializeField]
    public float scrollspeed;
    Vector2 startPos;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        startPos = transform.position;
    }
    private void Update()
    {
        float newPos = Mathf.Repeat(Time.time * scrollspeed, 10);
        transform.position = startPos - Vector2.up * newPos;
    }
}
