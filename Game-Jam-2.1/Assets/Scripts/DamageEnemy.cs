using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    public HealthSystem enemyHealth;
    public int time = 0;
    public void Start()
    {
        enemyHealth = GameObject.FindGameObjectWithTag("Enemy").GetComponent<HealthSystem>();
        print("HUrted");
    }

    void Update()
    {
        if (time > 0)
            time--;
    }

    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (enemyHealth)
            {
                print("Smack");
                enemyHealth.Damage(5f);
            }
            time += 120;
        }
    }
}