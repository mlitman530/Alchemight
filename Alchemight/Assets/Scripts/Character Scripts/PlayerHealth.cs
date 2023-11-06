using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public float MaxHealth;
    [SerializeField] private float CurrentHealth;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(float Amount)
    {
        CurrentHealth -= Amount;
        Debug.Log(CurrentHealth);

        if(CurrentHealth <= 0) {
            Debug.Log("The Player Died.");
            // resets health for testing, to be deleted
            CurrentHealth = MaxHealth;
        }
    }
}