using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowablePotion : MonoBehaviour
{


    [Header("References")]
    public Transform cam;
    public Transform attackPoint;
    private GameObject objectToThrowParent;
    public GameObject objectToThrow;
    public WeaponSwitch weaponSwitch;
    [Header("Settings")]
    public int totalThrows;
    public float throwCooldown;

    [Header("Throwing")]
    public float throwForce;
    public float throwUpwardForce;

    bool readyToThrow;
    // Start is called before the first frame update
    void Start()
    {
        readyToThrow = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(weaponSwitch.getCurrentItem().gameObject.tag == "Projectile")
        {
            objectToThrowParent = weaponSwitch.getCurrentItem().gameObject;
            objectToThrow = objectToThrowParent.GetComponent<Item>().throwableVersion;
            totalThrows = objectToThrowParent.GetComponent<Item>().heldCount;
        }
        
        
    }

    public void Throw()
    {
        if (objectToThrowParent.GetComponent<Item>().isHeld && readyToThrow && totalThrows > 0)
        {
            readyToThrow = false;
            GameObject projectile = Instantiate(objectToThrow, attackPoint.position, cam.rotation);
            Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

            Vector3 forceDirection = cam.transform.forward;
            RaycastHit hit;

            if (Physics.Raycast(cam.position, cam.forward, out hit, 500f))
            {
                forceDirection = (hit.point - attackPoint.position).normalized;
            }

            Vector3 forceToAdd = forceDirection * throwForce + transform.up * throwUpwardForce;
            projectileRb.AddForce(forceToAdd, ForceMode.Impulse);

            totalThrows--;
            //weaponSwitch.DecrementHeldCount(objectToThrowParent.GetComponent<Item>().id);

            Invoke(nameof(ResetThrow), throwCooldown);
        }
    }

    private void ResetThrow()
    {
        readyToThrow = true;
    }
}
