using System;
using UnityEngine;

namespace CodeBase
{
    public class CoinEnable : MonoBehaviour
    {
        public GameObject FireCoin;
        public GameObject WaterCoin;
        public GameObject Portal;
        private void OnTriggerEnter(Collider other)
        {
            if (this.CompareTag("Fire"))
            {
                FireCoin.SetActive(true);
            }
            else if (this.CompareTag("Water"))
            {
                WaterCoin.SetActive(true);
            }
        }

        private void Update()
        {
            if (FireCoin.activeSelf && WaterCoin.activeSelf)
            {
                Portal.SetActive(true);
            }
        }
    }
}
