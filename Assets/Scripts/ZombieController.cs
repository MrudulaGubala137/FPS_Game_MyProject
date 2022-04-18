using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent agent;
    Animator animator;
    public GameObject target;
    public enum STATE { IDLE, CHASE, ATTACK, DEATH}
    public STATE state=STATE.IDLE;
    void Start()
    {
        animator = GetComponent<Animator>();
        agent=GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case STATE.IDLE:
                if (NearPlayer())
                {
                    state = STATE.CHASE;
                }
                break;
            case STATE.CHASE:
                agent.SetDestination(target.transform.position);
                TurnOffAllAnim();
                animator.SetBool("IsRunning", true);
                print("running");
                if (DistanceToPlayer() < 8f)
                {
                    state = STATE.ATTACK;
                }
                else if (DistanceToPlayer()>30f)
                {  state = STATE.IDLE;

                }
                    break;
            case STATE.ATTACK:
                TurnOffAllAnim();
                animator.SetBool("IsAttack", true);
                 if (DistanceToPlayer() > 30f)
                {
                    state = STATE.IDLE;

                }
                break;
            case STATE.DEATH:
                TurnOffAllAnim();
                animator.SetBool("IsDeath", true);
                break;
            default:
                break;
        }

    }

    private float DistanceToPlayer()
    {
        return Vector3.Distance(target.transform.position, agent.transform.position);
    }

    public bool NearPlayer()
    {
        if(DistanceToPlayer() <30f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void TurnOffAllAnim()
    {
        animator.SetBool("IsDeath",false);
        animator.SetBool("IsRunning", false);
        animator.SetBool("IsAttack", false);
    }
}
