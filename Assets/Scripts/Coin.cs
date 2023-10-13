using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private int totalCoinsCollected;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        totalCoinsCollected = PlayerPrefs.GetInt("TotalCoins", 0);
        transform.Rotate(0, 100 * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameManager.numberOfCoins++;
            PlayerPrefs.SetInt("Coins", GameManager.numberOfCoins);
            totalCoinsCollected ++;
            PlayerPrefs.SetInt("TotalCoins", totalCoinsCollected);
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().PlaySound("PickUpCoin");

        }
    }
}
