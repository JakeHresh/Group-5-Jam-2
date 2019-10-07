using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransitions : MonoBehaviour
{
    public GameObject player;
    public int timer = 0;
    public Text timeDisplay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeDisplay.text = "TIME SURVIVED: " + timer / 60;
        timer++;
        if(player == null)
        {
            SceneManager.LoadScene("GameoverScene");
        }
        /*if(timer <= 0)
        {
            SceneManager.LoadScene("VictoryScene");
        }*/
    }
}
