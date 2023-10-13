using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockCar : MonoBehaviour
{
    public int price;

    public bool unlocked;
    public GameObject unlockButton;
    public Image lockedImage;
    public int coins;
    public GameObject selectButton;
    private int lockedKey;


    public int index;
    public Transform player;
    public GameObject carholder;
    public Rigidbody rb;
    public string nameCar;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        index = PlayerPrefs.GetInt("CharacterSelected");
        player = carholder.transform.GetChild(index);
        rb = player.GetComponent<Rigidbody>();
        nameCar = player.name;

        if (nameCar.Equals("DefaultBlue"))
        {
            lockedKey = PlayerPrefs.GetInt("BlueLocked", 0);
        }
        else if (nameCar.Equals("DefaultGrey"))
        {
            lockedKey = PlayerPrefs.GetInt("GreyLocked", 0);
        }
        else if (nameCar.Equals("DefaultRed"))
        {
            lockedKey = PlayerPrefs.GetInt("YellowLocked", 0);
        }
        else if (nameCar.Equals("DefaultYellow"))
        {
            lockedKey = PlayerPrefs.GetInt("RedLocked", 0);
        }
        else if (nameCar.Equals("Sedan"))
        {
            lockedKey = PlayerPrefs.GetInt("SedanLocked", 1);
        }
        else if (nameCar.Equals("MiniVan"))
        {
            lockedKey = PlayerPrefs.GetInt("MinivanLocked", 1);
        }
        else if (nameCar.Equals("Mustang"))
        {
            lockedKey = PlayerPrefs.GetInt("MustangLocked", 1);
        }
        else if (nameCar.Equals("Jeep"))
        {
            lockedKey = PlayerPrefs.GetInt("JeepLocked", 1);
        }
        else if (nameCar.Equals("SportCar"))
        {
            lockedKey = PlayerPrefs.GetInt("SportcarLocked", 1);
        }


        price = PlayerPrefs.GetInt("PriceCar", 0);
        coins = PlayerPrefs.GetInt("Coins", 0);


        if(lockedKey == 0)
        {
            unlocked = true;
        }
        else
        {
            unlocked = false;
        }


        if (!unlocked)
        {
            lockedImage.enabled = true;
            unlockButton.SetActive(true);
            selectButton.SetActive(false);
        }
        else
        {
            lockedImage.enabled = false;
            unlockButton.SetActive(false);
            selectButton.SetActive(true);
        }
    }

    public void UnlockButtonPressed()
    {
        if (price < coins)
        {
            coins -= price;
            PlayerPrefs.SetInt("Coins", coins);
            unlocked = true;



            if (nameCar.Equals("Sedan"))
            {
                PlayerPrefs.SetInt("SedanLocked", 0);
            }
            else if (nameCar.Equals("MiniVan"))
            {
                PlayerPrefs.SetInt("MinivanLocked", 0);
            }
            else if (nameCar.Equals("Mustang"))
            {
                PlayerPrefs.SetInt("MustangLocked", 0);
            }
            else if (nameCar.Equals("Jeep"))
            {
                PlayerPrefs.SetInt("JeepLocked", 0);
            }
            else if (nameCar.Equals("SportCar"))
            {
                PlayerPrefs.SetInt("SportcarLocked", 0);
            }
        }
    }
}
