using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SuperShot : MonoBehaviour
{
    public GameObject sunSuperProjectile;
    public float speed = 10;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject instantiatedSunProjectile = Instantiate(sunSuperProjectile,
                                                                transform.position,
                                                                transform.rotation)
                                                                as GameObject;
            Rigidbody instBulletRigidbody = sunSuperProjectile.GetComponent<Rigidbody>();
            instBulletRigidbody.AddForce(Vector3.forward * speed);
        }
    }
}
