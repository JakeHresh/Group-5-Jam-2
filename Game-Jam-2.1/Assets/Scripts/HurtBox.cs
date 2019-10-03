using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBox : MonoBehaviour
{
    public HealthSystem playerHealth;
    public void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthSystem>();
        print("HUrted");
    }

    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "AttackZone")
        {
            if (playerHealth)
            {
                print("Smack");
                playerHealth.Damage(5f);
            }
        }
       
    }
}
