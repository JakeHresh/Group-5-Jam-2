using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Player;
    public int Speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards (transform.position, Player.transform.position, Speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider Coll)
    {
        if(Coll.gameObject.tag == "Player")
        {
            Speed = 0;
        }
    }

    private void OnTriggerExit(Collider Coll)
    {
        if (Coll.gameObject.tag == "Player")
        {
            Speed = 3;
        }
    }
}
