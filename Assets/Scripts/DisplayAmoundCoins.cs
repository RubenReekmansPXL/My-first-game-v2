using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    class DisplayAmoundCoins : MonoBehaviour
    {
        public Text coinText;
        void Update()
        {
            coinText.text = "Coins: " + UnityEngine.PlayerPrefs.GetInt("Coins", 0).ToString();
        }
    }
}
