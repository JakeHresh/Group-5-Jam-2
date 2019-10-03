using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb;
    public float projectileDamage;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            if (collision.gameObject.tag != "Projectile")
            {
                rb.velocity = Vector3.zero;
                rb.useGravity = false;
                rb.isKinematic = true;
                gameObject.transform.parent = collision.transform;
                if (collision.gameObject.GetComponent<HealthSystem>()) //if collision object has healthSystem component
                {
                    HealthSystem healthSystem = collision.gameObject.GetComponent<HealthSystem>();
                    healthSystem.Damage(projectileDamage);
                }
            } 
        }
    }
}
