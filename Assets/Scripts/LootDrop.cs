using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootDrop : MonoBehaviour
{
    public GameObject coinModel; // Reference to the coin prefab to drop
    public float dropOffset = 1f; // Offset from the enemy position to drop the coin
    public int numberOfCoins = 1; // Number of coins to drop
    public float heightDif;
    public GameObject[] potionList;
    public GameObject[] keyList;
    
    

    public void DropCoins()
    {
        Debug.Log("Dropping Coins");
        Vector3 dropPosition = this.transform.position;
                
        GameObject gold =  Instantiate(coinModel, dropPosition, new Quaternion(90, 90, 0, 0)); // Gold drop
        gold.GetComponent<ItemBobber>().setHeightOffset(heightDif);
        
        gold.SetActive(true); // set gold object to active
    }

    public void DropPotions()
    {
        Debug.Log("Dropping Loot");
        Vector3 dropPosition = this.transform.position;

        if(Random.Range(0, 100) > 10)
        {
            int potionToDrop = Random.Range(0, potionList.Length);

            GameObject DroppedPotion = Instantiate(potionList[potionToDrop], dropPosition, Quaternion.identity);

            DroppedPotion.GetComponent<ItemBobber>().setHeightOffset(heightDif-1);
        }
    }

    public void DropKey()
    {
        Debug.Log("Dropping Key");
        Vector3 dropPosition = this.transform.position;

        if (Random.Range(0, 100) > 90)
        {
            int keyToDrop = Random.Range(0, keyList.Length);

            GameObject DroppedKey = Instantiate(keyList[keyToDrop], dropPosition, Quaternion.identity);

            DroppedKey.GetComponent<ItemBobber>().setHeightOffset(heightDif - 1);
        } 
    }
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setHeightOffset(float heightOffset)
    {
        heightDif = heightOffset;
    }
}
