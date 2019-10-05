using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperShotBehavior : MonoBehaviour
{
    public GameObject projectile;
    public float timer = 10f;
    private float timeReset;
    // Start is called before the first frame update
    void Start()
    {
        timeReset = timer;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Destroy(projectile);
        }
    }
}
