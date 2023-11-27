using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DisplayCost : MonoBehaviour
{

    public TextMeshProUGUI Cost;
    public int cost;
    public GameObject parent;
    public Item item;
    public Button parentButton;
   

    void Awake()
    {
        Cost = GetComponent<TextMeshProUGUI>();
        parent = transform.parent.gameObject;
        parentButton = parent.GetComponent<Button>();
        item = parent.GetComponentInChildren<Item>();
        cost = item.cost;
        Cost.text += cost;
    }
    // Start is called before the first frame update
    void Start()
    {
        Cost.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void displayCost()
    {
        Cost.enabled = true;
    }
    public void disableDisplay()
    {
        Cost.enabled = false;
    }
    
}

