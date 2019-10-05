using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBox : MonoBehaviour
{
    public HealthSystem playerHealth;
    public float timer = 0f;
    public void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthSystem>();
        print("HUrted");
    }

    void Update()
    {
        if(timer > 0)
            timer--;
    }

    // Start is called before the first frame update
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "AttackZone" && timer <= 0f)
        {
            if (playerHealth)
            {
                print("Smack");
                playerHealth.Damage(5f);
            }
            timer += 120f;
        }
       
    }
}
