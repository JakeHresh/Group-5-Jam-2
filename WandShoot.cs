﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScriptWandShoot : MonoBehaviour
{
    public GameObject magic;
    public float speed = 10;

    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject instMagic = Instantiate(magic, transform.position, Quaternion.identity) as GameObject;
            Rigidbody instMagicRigid = instMagic.GetComponent<Rigidbody>();
            instMagicRigid.AddForce(Vector3.forward * speed);
        }
    }
}
