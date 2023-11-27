using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
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

}
