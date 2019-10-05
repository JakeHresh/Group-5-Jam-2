using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    public HealthSystem enemyHealth;
    public float timer = 0f;
    public void Start()
    {
        enemyHealth = GameObject.FindGameObjectWithTag("Enemy").GetComponent<HealthSystem>();
        print("HUrted");
    }

    void Update()
    {
        if (timer > 0)
            timer--;
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
            timer += 120f;
        }
    }
}