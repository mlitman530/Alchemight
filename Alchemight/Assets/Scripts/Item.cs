using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public int id;
    public int purchaseLimit;
    public int purchaseCount;

    // Start is called before the first frame update
    void Start()
    {
        purchaseCount = 0;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
