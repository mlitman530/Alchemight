using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        //tracker = player.GetComponent<KeyTracker>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (this.tag == "GoldChest")
            {
                player.GetComponent<KeyTracker>().goldKeyCount += 1;
            }
            if (this.tag == "Black")
            {
                player.GetComponent<KeyTracker>().blackKeyCount += 1;
            }
            if (this.tag == "Green")
            {
                player.GetComponent<KeyTracker>().greenKeyCount += 1;
            }
            if (this.tag == "Red")
            {
                player.GetComponent<KeyTracker>().redKeyCount += 1;
            }

            // Destroy the pickup object
            Destroy(gameObject);
        }
    }
}
