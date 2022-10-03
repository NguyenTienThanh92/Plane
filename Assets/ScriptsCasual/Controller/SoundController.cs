using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;

public class SoundController : MonoBehaviour
{
    public static SoundController instance;
    public AudioClip Explosion;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        audioSource = GetComponent<AudioSource>();
    }
    private AudioSource audioSource;

    public void SoundExplosion()
    {
        audioSource.PlayOneShot(Explosion);
    }

}