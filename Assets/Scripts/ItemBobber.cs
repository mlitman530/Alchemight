using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBobber : MonoBehaviour
{

   public AnimationCurve myCurve;
    public float heightDif;

    private void Start()
    {
        
    }
    void Update()
    {
        transform.position = new Vector3(transform.position.x, myCurve.Evaluate((Time.time % myCurve.length)) + heightDif, transform.position.z);
    }


    public void setHeightOffset(float heightOffset)
    {
        heightDif = heightOffset + 1;
        
    }

}

