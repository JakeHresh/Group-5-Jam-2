using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    public HealthSystem enemyHealth;
    public void Start()
    {
        enemyHealth = GameObject.FindGameObjectWithTag("Enemy").GetComponent<HealthSystem>();
        print("HUrted");
    }

    

    // Start is called before the first frame update
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (enemyHealth)
            {
                print("Smack");
                enemyHealth.Damage(5f);
            }
        }
    }
}