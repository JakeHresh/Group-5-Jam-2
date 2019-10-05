using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SuperShot : MonoBehaviour
{
    public GameObject sunSuperProjectile;
    public float speed = 30;
    public Transform firingLocation;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            GameObject instantiatedSunProjectile = Instantiate(sunSuperProjectile, firingLocation.position, transform.rotation) as GameObject;
            Rigidbody instBulletRigidbody = instantiatedSunProjectile.GetComponent<Rigidbody>();
            instBulletRigidbody.velocity = transform.TransformDirection(Vector3.forward * speed);
        }
    }
}
