using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyTracker : MonoBehaviour
{
    public TextMeshProUGUI GoldKeyCount;
    public TextMeshProUGUI BlackKeyCount;
    public TextMeshProUGUI RedKeyCount;
    public TextMeshProUGUI GreenKeyCount;

    public int goldKeyCount;
    public int blackKeyCount;
    public int redKeyCount;
    public int greenKeyCount;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GoldKeyCount.text = "" + goldKeyCount;
        BlackKeyCount.text = "" + blackKeyCount;
        RedKeyCount.text = "" + redKeyCount;
        GreenKeyCount.text = "" + greenKeyCount;
    }
}
