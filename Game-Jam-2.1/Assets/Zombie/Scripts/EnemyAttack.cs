using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    public GameObject player, goal;
    public NavMeshAgent agent;
    //animations
    static Animator anim;
    //public HealthSystem HealthSystem; //pull damageAmount
    private bool follow, stay;
    private void OnTriggerEnter(Collider other)
    {
        //When enemy triggers goal, it stops and stays.
        Debug.Log("Enemy collided with: " + other.gameObject.tag);
        if (other.gameObject.tag == "Goal")
        {

            agent.isStopped = true;
            stay = true;
            //animation set to idle
            anim.SetBool("Idle", true);
            anim.SetBool("IsWalking", false);
        }

        //When enemy triggers player, it stops.
        if (other.gameObject.tag == "Player")
        {
            agent.isStopped = true;
            //animation set to idle
            anim.SetBool("Idle", false);
            anim.SetBool("IsWalking", false);
            anim.SetBool("Attacking", true);
        }

    }
    private void Attacking()
    {
        if (Vector3.Distance(player.transform.position, this.transform.position) < 3)
        {
            Debug.Log("Attacking");
            follow = false;
            anim.SetBool("Idle", false);
            anim.SetBool("IsWalking", false);
            anim.SetBool("Attacking", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //If player moves away from enemy after colliding, enemy follows
        if (other.gameObject.tag == "Player")
        {
            if (stay == false)
            {
                follow = true;
                agent.isStopped = false;
                Debug.Log("outside of collider");
            }
        }
    }

    void Start()
    {
        stay = false;
        follow = false;
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        //Below: (Not Working) when take damage, follow player.
        /*if (damageAmount >= 1)
        {
            Debug.Log("hit");
            follow = true;
        }*/
        Attacking();
        if (follow == true)
        {
            //follows player
            Vector3 playerPos = player.transform.position;
            agent.SetDestination(playerPos);
            //sets animation to walk
            anim.SetBool("Idle", false);
            anim.SetBool("IsWalking", true);
            Debug.Log("walking towards player");
        }

        else
        {
            //moves to castle
            Vector3 goalPos = goal.transform.position;
            agent.SetDestination(goalPos);
            //sets animation to walk
            anim.SetBool("Idle", false);
            anim.SetBool("IsWalking", true);
            Debug.Log("walking towards goal");
        }

    }
}