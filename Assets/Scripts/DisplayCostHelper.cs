using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class YourScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler 
{
    public DisplayCost displayCost;

    void Awake()
    {
        displayCost = GetComponentInChildren<DisplayCost>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        displayCost.displayCost();
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        displayCost.disableDisplay();
    }
}

   