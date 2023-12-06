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
    public int damageOverTime;
    public string effect;
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
            if (collision.gameObject.tag == "BasicEnemy" || collision.gameObject.tag == "TankEnemy" || collision.gameObject.tag == "SmallerEnemy")
            {
                if (effect == "freeze")
                {
                    FreezeEnemy(collision.contacts[0].point, radius);
                }
                else if (effect == "poison")
                {
                    PoisonEnemy(collision.contacts[0].point, radius);
                }
                else
                {
                    ExplosionDamage(collision.contacts[0].point, radius);
                }

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
            Debug.Log("Damage being delt: " + damage);
            if (hitCollider.gameObject.tag == "BasicEnemy" || hitCollider.gameObject.tag == "TankEnemy" || hitCollider.gameObject.tag == "SmallerEnemy" && hitCollider.gameObject.GetComponent<Damageable>())
            {
                hitCollider.gameObject.GetComponent<Damageable>().TakeDamage(damage);
            }
        }
    }

    private void FreezeEnemy(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.tag == "BasicEnemy" || hitCollider.gameObject.tag == "TankEnemy" || hitCollider.gameObject.tag == "SmallerEnemy" && hitCollider.gameObject.GetComponent<Damageable>())
            {
                hitCollider.gameObject.GetComponent<Damageable>().Freeze();
            }
        }
    }
    private void PoisonEnemy(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.tag == "BasicEnemy" || hitCollider.gameObject.tag == "TankEnemy" || hitCollider.gameObject.tag == "SmallerEnemy" && hitCollider.gameObject.GetComponent<Damageable>())
            {
                hitCollider.gameObject.GetComponent<Damageable>().Poison(damageOverTime);
            }
        }
    }
}
