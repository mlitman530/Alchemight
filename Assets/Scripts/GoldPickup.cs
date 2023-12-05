using UnityEngine;

public class GoldPickup : MonoBehaviour
{


    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Increment gold
            PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") + 1);

            

            // Destroy the pickup object
            Destroy(gameObject);
        }
    }
}




