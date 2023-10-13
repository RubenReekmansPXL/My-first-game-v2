using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OtherMenu : MonoBehaviour
{

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");

    }

    public void OpenSettings()
    {
        SceneManager.LoadScene("Settings");

    }

    public void ResetHighScore()
    {
        PlayerPrefs.SetInt("HighScore", 0);
    }
    public void ResetCoins()
    {
        PlayerPrefs.SetInt("Coins", 0);
    }
}
