using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ItemPurchase : MonoBehaviour
{
    private int itemId;
    public Inventory playerInventory;
    public PurchasableItems PurchasableItems;
    public GameObject purchaseLimitObject;
    public GameObject insufficientGoldObject;
    public GameObject shop;
    public AudioSource audioSource;
    public AudioClip[] sounds;


    void Awake()
    {
        purchaseLimitObject = GameObject.Find("Purchase Limit Reached");
        insufficientGoldObject = GameObject.Find("Insufficient Gold");
        shop = GameObject.Find("Shop");

        audioSource = shop.GetComponent<AudioSource>();


    }
    void Start()
    {

        purchaseLimitObject.SetActive(false);
        insufficientGoldObject.SetActive(false);



    }

    // Update is called once per frame
    void Update()
    {

    }

    private void getId()
    {
        Item purchasedItem = GetComponentInChildren<Item>();

        itemId = purchasedItem.id;
        Debug.Log(itemId);
    }

    private bool checkPurchaseLimit()
    {

        if (GetComponentInChildren<Item>().purchaseCount > GetComponentInChildren<Item>().purchaseLimit)
        {
            Debug.Log("Purchase Limit is reached");
            //this.gameObject.GetComponent<Button>().interactable = false;
            purchaseLimitObject.SetActive(true);
            audioSource.PlayOneShot(sounds[0]);
            return false;
        }
        else
        {
            Debug.Log("Increased Purchase Count");
            GetComponentInChildren<Item>().purchaseCount++;

        }
        return true;

    }


    private bool checkCost()
    {
        if (GetComponentInChildren<Item>().cost > playerInventory.currentGoldCount)
        {
            Debug.Log("Not enough gold");
            insufficientGoldObject.SetActive(true);
            audioSource.PlayOneShot(sounds[0]);
            return false;
        }
        else
        {
            Debug.Log("Item Can Be Purchased");
            playerInventory.currentGoldCount -= GetComponentInChildren<Item>().cost;

        }
        return true;
    }

    private void addItemToInventory()
    {
        playerInventory.inventory.Add(itemId);
        audioSource.PlayOneShot(sounds[1]);
        Debug.Log("Inventory Count: " + playerInventory.inventory.Count);
        if (PurchasableItems.itemRegistry.ContainsKey(itemId))
        {
            GameObject itemObject = PurchasableItems.itemRegistry[itemId];


            Debug.Log("Item added to inventory: " + itemObject.name);
        }
        else
        {
            Debug.LogError("Item with itemId not found in the dictionary.");
        }
    }

    private void clearItem()
    {
        Destroy(gameObject);
    }

    public void clickAction()
    {
        getId();
        if (checkPurchaseLimit() && checkCost())
        {
            addItemToInventory();

        }
        //clearItem();
    }
}
