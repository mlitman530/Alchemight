using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

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
    public UnityEngine.UI.Slider healthBar;
    public UnityEngine.UI.Slider enemyHealthBar;
    

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
            UnityEngine.Cursor.lockState = CursorLockMode.None;
            UnityEngine.Cursor.visible = true;
            SceneManager.LoadScene("Dead");
            return;
        }

        if (this.gameObject.tag == "BasicEnemy" || this.gameObject.tag == "TankEnemy" || this.gameObject.tag == "SmallerEnemy") 
        {
            animator.SetTrigger("die");
            lootDrops = this.GetComponent<LootDrop>();

            if (lootDrops != null)
            {
                lootDrops.setHeightOffset(this.gameObject.transform.position.y);
                lootDrops.DropCoins(); // Trigger dropping coins on enemy death
                lootDrops.DropPotions();
                lootDrops.DropKey();
            }
        }
        else
        {
            Destroy(gameObject);
        }

    }


}
