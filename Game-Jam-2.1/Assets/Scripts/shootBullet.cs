using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootBullet : MonoBehaviour
{
    public GameObject bulletEmitter;
    public float bulletSpeed = 10;
    public GameObject projectile;
    public GameObject lightProjectile;
    public GameObject target;
	static Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Clicked();
    }

    public void Clicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
			anim.SetBool("Fire",true);
            GameObject temporary_bullet_handler;
            temporary_bullet_handler = Instantiate(projectile, bulletEmitter.transform.position, bulletEmitter.transform.rotation) as GameObject;
            temporary_bullet_handler.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward, Camera.main.transform.up) * Quaternion.Euler(90f, 0f, 0f);
            //temporary_bullet_handler.transform.Rotate(Vector3.left * 90);

            Rigidbody temporary_rigidbody;
            temporary_rigidbody = temporary_bullet_handler.GetComponent<Rigidbody>();
            temporary_rigidbody.velocity = Camera.main.transform.forward * 60f;

            Destroy(temporary_bullet_handler, 10.0f);
            //GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
            // bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);

        }
		if (Input.GetMouseButtonUp(0))
		{
			anim.SetBool("Fire",false);
		}
        if (Input.GetMouseButtonDown(1))
        {
            anim.SetBool("Fire", true);
            GameObject temporary_bullet_handler;
            temporary_bullet_handler = Instantiate(lightProjectile, bulletEmitter.transform.position, bulletEmitter.transform.rotation) as GameObject;
            temporary_bullet_handler.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward, Camera.main.transform.up) * Quaternion.Euler(90f, 0f, 0f);
            //temporary_bullet_handler.transform.Rotate(Vector3.left * 90);

            Rigidbody temporary_rigidbody;
            temporary_rigidbody = temporary_bullet_handler.GetComponent<Rigidbody>();
            temporary_rigidbody.velocity = Camera.main.transform.forward * 60f;

            Destroy(temporary_bullet_handler, 10.0f);
            //GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
            // bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);

        }

    }

}