/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.StrategyPattern
{
    public class PotionRunner : MonoBehaviour
    {
        private IPotion m_currentPotion;

        public IPotion CurrentPotion
        {
            get => m_currentPotion;
            set => m_currentPotion = value;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_currentPotion?.Use();
            }
        }
    }
}*/