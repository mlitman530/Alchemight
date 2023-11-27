using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootDrop : MonoBehaviour
{
    public GameObject coinPrefab; // Reference to the coin prefab to drop
    public float dropOffset = 1.0f; // Offset from the enemy position to drop the coin
    public int numberOfCoins = 1; // Number of coins to drop

    // Start is called before the first frame update
    public GameObject Gold;
    public Transform transform;

    public void DropCoins()
    {
        for (int i = 0; i < numberOfCoins; i++)
        {
            Vector3 dropPosition = transform.position + Vector3.up * dropOffset;
            GameObject gold =  Instantiate(Gold, dropPosition + new Vector3(0.0f, 1.0f, 0.0f), Quaternion.identity);
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
