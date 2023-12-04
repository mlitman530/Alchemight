using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootDrop : MonoBehaviour
{
    public GameObject coinModel; // Reference to the coin prefab to drop
    public float dropOffset = 1.0f; // Offset from the enemy position to drop the coin
    public int numberOfCoins = 1; // Number of coins to drop
    public GameObject Gold;
    public Transform transform;

    public void DropCoins()
    {
        Vector3 dropPosition = transform.position;
        GameObject gold =  Instantiate(coinModel, dropPosition + new Vector3(0.0f, 1.0f, 0.0f), Quaternion.identity); // Gold drop
        gold.SetActive(true); // set gold object to active
    }
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
