using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Damageable : MonoBehaviour
{

    public float maxHealth = 100f;
    public float currentHealth;
    public bool invincible = false;
    public Animator animator;
    public AudioSource[] audios;
    public LootDrop lootDrops;

    // Start is called before the first frame update
    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {

        if (invincible)
            return;
        else
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                Die();
                GetComponent<Collider>().enabled = false;
            }
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

        if (this.gameObject.tag == "Enemy") 
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
