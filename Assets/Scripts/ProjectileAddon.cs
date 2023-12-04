using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class ProjectileAddon : MonoBehaviour
{

    private Rigidbody rb;
    public float radius;
    private bool targetHit;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "Projectile")
        {


            if (collision.gameObject.tag == "Enemy")
            {
                ExplosionDamage(collision.contacts[0].point, radius);

            }
            Debug.Log("Hit " + collision.gameObject.name);
            //this.gameObject.GetComponent<ParticleSystem>().Play();
            Destroy(this.gameObject);
        }
    }

    void ExplosionDamage(Vector3 center, float radius)
    {
        
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.tag == "Enemy" && hitCollider.gameObject.GetComponent<Damageable>())
            {
                hitCollider.gameObject.GetComponent<Damageable>().TakeDamage(damage);
            }
        }
    }
}
