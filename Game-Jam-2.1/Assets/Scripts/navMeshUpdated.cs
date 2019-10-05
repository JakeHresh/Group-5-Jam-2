using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navMeshUpdated : MonoBehaviour
{
    public Transform player;
    public Transform goal;
    public NavMeshAgent agent;
    public float Timer;
    public float seconds;
    public Animator anim;
    public float extraRotationSpeed;
    public HealthSystem playerHealth;

    private bool stop;
    private bool attack;
    /// <summary>
    /// When the zombie enters the castle it should determine what is closer, player or the goal. 
    /// If the player is closer than the goal, it should go to the player.
    /// </summary>
    // Start is called before the first frame update
    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.transform;
        playerHealth = playerObject.GetComponent<HealthSystem>();
        //goal = GameObject.FindGameObjectWithTag("Goal").transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        Timer = seconds;
        //anim.SetBool("Idle", true);
        anim.SetBool("IsWalking", true);
    }

    // Update is called once per frame
    void Update()
    {
        CountDown();
        Attack();
        checkMove();
        extraRotation();
        agent.isStopped = stop;
    }
    void DeterminePath()
    {
        float goalDistance = Vector3.Distance(goal.transform.position, transform.position);
        float playerDistance = Vector3.Distance(player.transform.position, transform.position);

        
        if (goalDistance > playerDistance)
        {
            anim.SetBool("Idle", false);
            anim.SetBool("IsWalking", true);
            print("Going to player");
            //if player is closer than goal goto player. 
            Goto(player);
        }
        else
        {
            if (goal)
            {
                anim.SetBool("Idle", false);
                anim.SetBool("IsWalking", true);
                print("Going to Goal");
                Goto(goal);
            }
           
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "StopZone")
        {
            print("STOPP");
            attack = true;
            stop = true;
        }
        if (other.gameObject.tag == "AttackZone")
        {
            print("ATTACK");
            attack = true;
            stop = true;

        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "StopZone")
        {
            stop = false;
            anim.SetBool("IsWalking", true);
            anim.SetBool("Idle", false);
        }
        if (other.gameObject.tag == "AttackZone")
        {
            attack = false;
            stop = false;
            anim.SetBool("IsWalking", true);
            anim.SetBool("Idle", false);
        }
    }
    void Attack()
    {
        ///<summary>
        ///If zombie is withing collider "ATTACKZONE" then stop moving, and attack.
        ///</summary>
        anim.SetBool("Attacking", attack);
    }

    void Goto(Transform pointToGo)
    {
        ///<summary>
        ///Pass in point to go to.
        ///Set destination to point. 
        ///Have a timer on what point can be to limit "twitching"
        ///</summary>
        if (CountDown() <= 0f)
        {
            agent.isStopped = true;
            agent.destination = pointToGo.position;
            agent.updatePosition = true;
            agent.updateRotation = true;
        }
    }
    float CountDown()
    {
        if (Timer >= 0)
        {
            Timer -= 1 * Time.deltaTime;
            float countDown = Timer;
            return countDown;
        }
        else
        {
            print("tock");
            Timer = seconds;
            return 0f;
        }
    }
    void checkMove()
    {
        if (!stop)
        {
            //if agent is not stopped then update path
            DeterminePath();

        }
        /*else
        {
            anim.SetBool("Idle", true);
            anim.SetBool("IsWalking", false);
        }*/
    }
    void extraRotation()
    {
        Vector3 lookrotation = agent.steeringTarget - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookrotation), extraRotationSpeed * Time.deltaTime);
    }
}
