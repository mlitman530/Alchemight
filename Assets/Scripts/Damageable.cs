using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Damageable : MonoBehaviour
{

    public float maxHealth = 100f;
    public float currentHealth;
    public float maxPlayerHealth = 100f;
    public float currentPlayerHealth;
    public bool invincible = false;
    public Animator animator;
    public AudioSource[] audios;
    public LootDrop lootDrops;
    public Slider healthBar;
    public Slider enemyHealthBar;

    // Start is called before the first frame update
    void Awake()
    {
        currentHealth = maxHealth;
        currentPlayerHealth = maxPlayerHealth;
    }

    public void TakeDamage(float damage)
    {

        if (invincible)
            return;
        else
        {
            currentHealth -= damage;
            enemyHealthBar.value = currentHealth; // enemy health bar
                
            if (currentHealth <= 0)
            {
                Die();
                GetComponent<Collider>().enabled = false;
            }
            else
            {
                animator.SetTrigger("damage");
                //flash red???
            }
                
            // if (this.gameObject.tag == "Player") 
            // {
            //     currentPlayerHealth -= damage;
            //     healthBar.value = currentPlayerHealth;
            //     if (currentPlayerHealth <= 0) 
            //     {
            //         Die();
            //         GetComponent<Collider>().enabled = false;
            //     }
            // }
            
        }
    }

    void Die()
    {
        if (this.gameObject.tag == "Player")
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("Dead");
            return;
        }

        if (this.gameObject.tag == "BasicEnemy" || this.gameObject.tag == "TankEnemy" || this.gameObject.tag == "SmallerEnemy") 
        {
            animator.SetTrigger("die");
            lootDrops = GetComponent<LootDrop>();
            if (lootDrops != null)
            {
                lootDrops.DropCoins(); // Trigger dropping coins on enemy death
            }
        }
        else
        {
            Destroy(gameObject);
        }

    }


}
