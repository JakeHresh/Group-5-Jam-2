using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SuperShot : MonoBehaviour
{
    public AudioClip SFXClip;
    public AudioSource SFXSource;
    public GameObject sunSuperProjectile;
    public float speed = 30;
    public Transform firingLocation;
    public float shootBufferTrack = 30f;
    private float shootBuffer = 0f;
    void Start()
    {
        SFXSource.clip = SFXClip;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && shootBuffer <= 0)
        {
            GameObject instantiatedSunProjectile = Instantiate(sunSuperProjectile, firingLocation.position, transform.rotation) as GameObject;
            Rigidbody instBulletRigidbody = instantiatedSunProjectile.GetComponent<Rigidbody>();
            instBulletRigidbody.velocity = transform.TransformDirection(Vector3.forward * speed);
            SFXSource.Play();
            shootBuffer = shootBufferTrack;
        }
        if(shootBuffer > 0)
        {
            shootBuffer--;
        }
    }
}
