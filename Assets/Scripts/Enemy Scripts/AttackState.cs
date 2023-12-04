using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : StateMachineBehaviour
{
    Transform player;
    RaycastHit hit;
    AnimatorStateInfo stateInfo;
    public AudioClip attackAudio;
    public AudioClip deathAudio;
    AudioSource audioSource;
    [SerializeField] float basicDamage = 20f;
    [SerializeField] float tankDamage = 40f;
    [SerializeField] float smallerDamage = 10f;

    private Damageable damageable;
    private PlayerController playerDamageable; 
    private float lastAttackTime;
    public float attackCooldown = 3f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        damageable = player.GetComponent<Damageable>();
        playerDamageable = player.GetComponent<PlayerController>();
        lastAttackTime = -attackCooldown;
        audioSource = animator.GetComponent<AudioSource>();
        stateInfo = animator.GetCurrentAnimatorStateInfo(0);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.LookAt(player);
        float distance = Vector3.Distance(player.position, animator.transform.position);
        if (distance > 3.5f) {
            animator.SetBool("isAttacking", false);
        }
        if (distance < 2.5f) 
        {
            if (Time.time - lastAttackTime > attackCooldown && distance <= 2.5f)
            {
                AttackPlayer();
                lastAttackTime = Time.time;
            }
        }
    }
    private void AttackPlayer()
    {
        // Attack the player
         if (attackAudio != null && audioSource != null)
        {
            audioSource.PlayOneShot(attackAudio);
        }
        // NOT WORKING YET
        // if (stateInfo.IsTag("BasicAttack"))
        // {
        //     Debug.Log("BASIC ATTACK");
        //     playerDamageable.TakeDamage(basicDamage);
        // }
        // if (stateInfo.IsTag("TankAttack"))
        // {
        //     Debug.Log("TANK ATTACK");
        //     playerDamageable.TakeDamage(tankDamage);
        // }
        // if (stateInfo.IsTag("SmallerAttack"))
        // {
        //     Debug.Log("SMALLER ATTACK");
        //     playerDamageable.TakeDamage(smallerDamage);
        // }
        playerDamageable.TakeDamage(basicDamage);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       // Implement code that processes and affects root motion
    }

    // OnStateIK is called right after Animator.OnAnimatorIK()
    override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       // Implement code that sets up animation IK (inverse kinematics)
    }
}