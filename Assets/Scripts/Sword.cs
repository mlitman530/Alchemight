using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;


    public class Sword : MonoBehaviour
    {
        Transform cam;

        private Animator anim;
        public AudioSource[] audios;

        [SerializeField] float range = 5f;
        [SerializeField] float damage;
        //[SerializeField] float swingDelay = .5f;

        private void OnEnable()
        {
            cam = Camera.main.transform;
            anim = GetComponent<Animator>();

            //Debug.Log(range);
        }

        public void Update()
        {
            damage = PlayerPrefs.GetInt("Strength");
        }

        public void Swing()
           {
            RaycastHit hit;
            audios[0].Play();
            anim.SetTrigger("Swing");
            if (Physics.Raycast(cam.position, cam.forward, out hit, range))
            {

                //print(hit.collider.name);
                if (hit.collider.GetComponent<Damageable>() != null)
                {
                    audios[1].Play();
                    hit.collider.GetComponent<Damageable>().TakeDamage(damage);
                }
            }
        }
    }
