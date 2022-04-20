using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent agent;
    Animator animator;
    public GameObject target;
    public float stoppingDistance;
    public enum STATE { IDLE, CHASE, ATTACK, DEATH}
    public STATE state=STATE.IDLE;
    PlayerMovement playerMovement;
    public float attackTime;
    public float currentTime;
    bool isGameOver=false;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        agent=GetComponent<NavMeshAgent>();
        playerMovement=target.GetComponent<PlayerMovement>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null && isGameOver == false)
        {
            target = GameObject.FindGameObjectWithTag("Player");
            return;
        }
        switch (state)
        {
            case STATE.IDLE:
                TurnOffAllAnim();
                if (NearPlayer())
                {
                    print("Now Idle");
                    state = STATE.CHASE;
                }
                break;
            case STATE.CHASE:
                TurnOffAllAnim();
                animator.SetBool("IsRunning", true);
                agent.SetDestination(target.transform.position);
                agent.stoppingDistance = 4f;
                print("running");
                if (DistanceToPlayer()<=4f)
                {
                    print("From Chase Going To Attack");
                    state = STATE.ATTACK;
                }
                
                
                else if(DistanceToPlayer() > 20f)
                {
                    print("From Chase Going To Idle");
                    state=STATE.IDLE;
                }
                break;
            case STATE.ATTACK:
                TurnOffAllAnim();
                animator.SetBool("IsAttack", true);
                 if (DistanceToPlayer() > 4f)
                {
                    print("From attack Going To chase");
                    state = STATE.CHASE;
                }
                Attack();
                
                break;
            case STATE.DEATH:
                print("Dead state");
                TurnOffAllAnim();
                animator.SetBool("IsDead", true);
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
        if(DistanceToPlayer() <20f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void EnemyDead()
    {
        print("death fun");
        state = STATE.DEATH;
    }
    public void TurnOffAllAnim()
    {
        animator.SetBool("IsDead",false);
        animator.SetBool("IsRunning", false);
        animator.SetBool("IsAttack", false);
    }
    public void Attack()
    {
        currentTime = currentTime - Time.deltaTime;
        if (currentTime <= 0f)
        {
            playerMovement.health--;
            playerMovement.healthText.text="Health:"+playerMovement.health;
            Debug.Log(playerMovement.health);
            currentTime = attackTime;
        }
        if (playerMovement.health == 0)
        {
          isGameOver = true;
            TurnOffAllAnim();
            playerMovement.GameOver();
        }
    }
}
