using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarValues : MonoBehaviour
{
    public int price;
    public string name;

    public Text priceText;
    public Text nameText;
    public int coins;
    public Text freeText;

    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        coins = PlayerPrefs.GetInt("Coins", 0);
        nameText.text = name;
        if(name.Equals("Blue default") || name.Equals("Grey default") || name.Equals("Yellow default") || name.Equals("Red default"))
        {
            freeText.enabled = true;
            priceText.enabled = false;
        }
        else
        {
            priceText.text = price.ToString();
            freeText.enabled = false;
            priceText.enabled = true;
        }
        PlayerPrefs.SetInt("PriceCar", price);
    }
}
