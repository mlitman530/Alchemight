using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int HP = 100;
    public Animator animator;

    public void TakeDamage(int damageAmount) 
    {
        HP -= damageAmount;
        if (HP <= 0) {
            //play enemy death animation
            animator.SetTrigger("die");

        } else {
            //play hit animation
            animator.SetTrigger("damage");
        }
    }

    public void Freeze()
    {
        animator.SetTrigger("freeze");
    }

    public void Poison(int damageOverTime)
    {
        for (int i = 0; i < 10; i++)
        {
            HP -= damageOverTime;
            if (HP <= 0) {
                //play enemy death animation
                animator.SetTrigger("die");

            } else {
                //play hit animation
                animator.SetTrigger("damage");
            }
            // Wait 1 second
        }
    }

}
