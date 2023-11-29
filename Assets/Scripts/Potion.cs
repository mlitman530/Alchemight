/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DesignPatterns.StrategyPattern
{
    public class Potion : MonoBehaviour
    {
        private IStrategy _strategy;

        public Potion()
        {

        }

        public Potion(IStrategy strategy)
        {
            this._strategy = strategy;
        }

        public void SetStrategy(IStrategy strategy)
        {
            this._strategy = strategy;
        }

        public void getPotionToDrink()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public interface IStrategy
        {
            object DoAlgorithm(object data);
        }
    }
}
*/