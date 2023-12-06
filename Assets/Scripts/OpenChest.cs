using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class OpenChest : MonoBehaviour
{

    public GameObject player;
    public GameObject[] potionList;
    public GameObject coinModel;
    public float heightDif;

    public AudioSource audioSource;
    public AudioClip chestOpen;
    public AudioClip error;

    public TextMeshProUGUI needKey;

    // Start is called before the first frame update

    private void Awake()
    {
        needKey = GameObject.Find("needKey").GetComponent<TextMeshProUGUI>();
        player = GameObject.Find("Player");
    }
    void Start()
    {
        
        needKey.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DropPotions(string color)
    {
        //Debug.Log("Dropping Loot");
        Vector3 dropPosition = this.transform.position;

        heightDif = this.transform.position.y;
        int randomNum = Random.Range(0, 100);
        if (color != "Starter")
        {
            if (randomNum >= 95)
            {
                int potionToDrop = Random.Range(0, potionList.Length);
                for (int i = 0; i < 20; i++)
                {
                    GameObject DroppedPotion = Instantiate(potionList[potionToDrop], dropPosition, Quaternion.identity);

                    DroppedPotion.GetComponent<ItemBobber>().setHeightOffset(heightDif - 1);
                }
            }
            if (randomNum < 95 && randomNum >= 85)
            {
                int potionToDrop = Random.Range(0, potionList.Length);
                for (int i = 0; i < 15; i++)
                {
                    GameObject DroppedPotion = Instantiate(potionList[potionToDrop], dropPosition, Quaternion.identity);

                    DroppedPotion.GetComponent<ItemBobber>().setHeightOffset(heightDif - 1);
                }
            }
            if (randomNum < 85 && randomNum >= 65)
            {
                int potionToDrop = Random.Range(0, potionList.Length);
                for (int i = 0; i < 10; i++)
                {
                    GameObject DroppedPotion = Instantiate(potionList[potionToDrop], dropPosition, Quaternion.identity);

                    DroppedPotion.GetComponent<ItemBobber>().setHeightOffset(heightDif - 1);
                }
            }
            if (randomNum < 65 && randomNum >= 35)
            {
                int potionToDrop = Random.Range(0, potionList.Length);
                for (int i = 0; i < 6; i++)
                {
                    GameObject DroppedPotion = Instantiate(potionList[potionToDrop], dropPosition, Quaternion.identity);

                    DroppedPotion.GetComponent<ItemBobber>().setHeightOffset(heightDif - 1);
                }
            }
            if (randomNum < 35 && randomNum >= 0)
            {
                int potionToDrop = Random.Range(0, potionList.Length);
                for (int i = 0; i < 3; i++)
                {
                    GameObject DroppedPotion = Instantiate(potionList[potionToDrop], dropPosition, Quaternion.identity);

                    DroppedPotion.GetComponent<ItemBobber>().setHeightOffset(heightDif - 1);
                }
            }
        }
        if(color == "Gold")
        {
            for(int i = 0; i < 50; i++)
            {
                DropCoins();
            }
        }
        if (color == "Black")
        {
            for (int i = 0; i < 25; i++)
            {
                DropCoins();
            }
        }
        if (color == "Green")
        {
            for (int i = 0; i < 10; i++)
            {
                DropCoins();
            }
        }
        if (color == "Red")
        {
            for (int i = 0; i < 5; i++)
            {
                DropCoins();
            }
        }
        if (color == "Starter")
        {
            int potionToDrop = Random.Range(0, 4);
            GameObject DroppedPotion = Instantiate(potionList[potionToDrop], dropPosition, Quaternion.identity);
            DroppedPotion.GetComponent<ItemBobber>().setHeightOffset(heightDif - 1);
            for (int i = 0; i < 5; i++)
            {
                DropCoins();
            }
        }

    }

    public void DropCoins()
    {
        //Debug.Log("Dropping Coins");
        Vector3 dropPosition = this.transform.position;

        GameObject gold = Instantiate(coinModel, dropPosition, new Quaternion(90, 90, 0, 0)); // Gold drop
        gold.GetComponent<ItemBobber>().setHeightOffset(heightDif);

        gold.SetActive(true); // set gold object to active
    }

    public IEnumerator failure()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(error);
        }
        needKey.enabled = true;
        yield return new WaitForSeconds(2);
        needKey.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(this.tag == "GoldChest" && player.GetComponent<KeyTracker>().goldKeyCount > 0)
            {
                audioSource.PlayOneShot(chestOpen);
                DropPotions("Gold");
                player.GetComponent<KeyTracker>().goldKeyCount--;
                PlayerPrefs.SetInt("GoldChestOpened", 1);
                // Destroy the pickup object
                Destroy(gameObject);
            }
            else if(this.tag == "Black" && player.GetComponent<KeyTracker>().blackKeyCount > 0)
            {
                audioSource.PlayOneShot(chestOpen);
                DropPotions("Black");
                player.GetComponent<KeyTracker>().blackKeyCount--;
                PlayerPrefs.SetInt("BlackChestOpened", 1);
                // Destroy the pickup object
                Destroy(gameObject);
            }
            else if(this.tag == "Green" && player.GetComponent<KeyTracker>().greenKeyCount > 0)
            {
                audioSource.PlayOneShot(chestOpen);
                DropPotions("Green");
                player.GetComponent<KeyTracker>().greenKeyCount--;
                PlayerPrefs.SetInt("GreenChestOpened", 1);
                // Destroy the pickup object
                Destroy(gameObject);
            }
            else if(this.tag == "Red" && player.GetComponent<KeyTracker>().redKeyCount > 0)
            {
                audioSource.PlayOneShot(chestOpen);
                DropPotions("Red");
                player.GetComponent<KeyTracker>().redKeyCount--;
                PlayerPrefs.SetInt("RedChestOpened", 1);
                // Destroy the pickup object
                Destroy(gameObject);
            }
            else if (this.tag == "Starter")
            {
                audioSource.PlayOneShot(chestOpen);
                DropPotions("Starter");
                // Destroy the pickup object
                Destroy(gameObject);
            }
            else
            {
                StartCoroutine(failure());
            }




        }
    }

}
