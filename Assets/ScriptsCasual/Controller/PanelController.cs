using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    // Start is called before the first frame update
    public Text score;

    // Update is called once per frame
    void Update()
    {
        score.text = " " + GameManager.instance.scorePlayer.ToString();
    }
}
