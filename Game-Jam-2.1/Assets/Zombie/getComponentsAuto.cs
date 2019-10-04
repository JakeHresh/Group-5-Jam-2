using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getComponentsAuto : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public GameObject goal;
    public EnemyNav nav;
    void Start()
    {
        nav = GetComponent<EnemyNav>();
        player = GameObject.FindGameObjectWithTag("Player");
        goal = GameObject.FindGameObjectWithTag("Goal");

        nav.player = player;
        nav.goal = goal;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
