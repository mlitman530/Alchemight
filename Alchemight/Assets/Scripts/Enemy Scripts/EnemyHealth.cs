using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public float MaxEnemyHealth;
    [SerializeField] private float CurrentEnemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        CurrentEnemyHealth = MaxEnemyHealth;
    }

    // Update is called once per frame
    public void EnemyTakesDamage(float Amount)
    {
        CurrentEnemyHealth -= Amount;

        if (CurrentEnemyHealth <= 0) {
            Debug.Log("Enemy is dead.");
            CurrentEnemyHealth = MaxEnemyHealth;
        }
    }
}
