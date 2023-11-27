using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Item : MonoBehaviour
{

    public int id;
    public int heldCount;
    public int purchaseLimit;
    public int purchaseCount;
    public bool isHeld;
    public int cost;

    // Start is called before the first frame update
    void Start()
    {
        purchaseCount = 0;
        isHeld = false;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "SewerLayout")
        {
            if (heldCount == 0)
            {
                deactivateItem();
            }
        }
    }

    public void activateItem()
    {
        isHeld = true;
        
        gameObject.SetActive(true);
        
    }

    public void deactivateItem()
    {
        Debug.Log("Deactivated");
        isHeld = false;
        
        gameObject.SetActive(false);
        
    }
}
