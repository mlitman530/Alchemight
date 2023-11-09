using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchasableItems : MonoBehaviour
{

    public Button item1;
    public Button item2;
    public Button item3;
    public Button item4;
    public Button item5;
    public Button item6;
    private Dictionary<int, GameObject> _itemRegistry = new Dictionary<int, GameObject>();
    public  Dictionary<int, GameObject> itemRegistry {  
        get 
        { 
            return _itemRegistry; 
        } 
        set 
        { 
            _itemRegistry = new Dictionary<int, GameObject>() { { 0, item1.transform.GetChild(0).gameObject }, { 1, item2.transform.GetChild(0).gameObject }, { 2, item3.transform.GetChild(0).gameObject }, { 3, item4.transform.GetChild(0).gameObject }, { 4, item5.transform.GetChild(0).gameObject }, { 5, item6.transform.GetChild(0).gameObject } };
        }
    }

    
    public void Awake()
    {
        itemRegistry = new Dictionary<int, GameObject>() {
        { 0, item1.transform.GetChild(0).gameObject },
        { 1, item2.transform.GetChild(0).gameObject },
        { 2, item3.transform.GetChild(0).gameObject },
        { 3, item4.transform.GetChild(0).gameObject },
        { 4, item5.transform.GetChild(0).gameObject },
        { 5, item6.transform.GetChild(0).gameObject }
    };

        /*for (int i = 0; i < itemRegistry.Count; i++) {
            Debug.Log("Item: " + itemRegistry[i]); 
        }*/
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
