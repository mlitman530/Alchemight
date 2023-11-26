/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.StrategyPattern
{
    [RequireComponent(typeof(PotionRunner))]
    public class PotionChanger : MonoBehaviour
    {
        private PotionRunner m_potionRunner;

        private void Awake()
        {
            m_potionRunner = GetComponent<PotionRunner>();
        }

        private void Start()
        {
            m_potionRunner.CurrentPotion = new Sword();
        }

        private void Update()
        {
            IPotion currentPotion = m_potionRunner.CurrentPotion;

            if (Input.GetKeyDown(KeyCode.F) && currentPotion is not Sword)
                m_potionRunner.CurrentPotion = new Sword();
            
        }
    }
}*/