﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    public GameObject player;
    public float timer = 120f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(player == null)
        {
            SceneManager.LoadScene("GameoverScene");
        }
        else if(timer <= 0)
        {
            SceneManager.LoadScene("VictoryScene");
        }
    }
}
