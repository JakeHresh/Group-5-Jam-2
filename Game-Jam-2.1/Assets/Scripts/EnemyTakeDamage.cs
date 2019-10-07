using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour
{
    public HealthSystem health;
    // Start is called before the first frame update
    void Start()
    {
        health = gameObject.GetComponent<HealthSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            print("Smack");
            health.Damage(5f);
            Debug.Log("HIT THE ENEMY");
        }
    }
}
