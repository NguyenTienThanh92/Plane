using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranshootController : MonoBehaviour
{
    public Animator effect;
    public bool checkAnimator;
    public static TranshootController instance;
    // Start is called before the first frame update

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        //fireEffect = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if ( checkAnimator == false)
        //{
        //    fireEffect.SetBool("shoot", false);
        //}
        //if (checkAnimator == true)
        //{
        //    fireEffect.SetBool("shoot", true);
        //}
        //fireEffect.Play("fireEffect");
    }
    public void PlayAnimator()
    {
        effect.Play("effect");
    }
}