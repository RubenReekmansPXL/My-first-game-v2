using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text coinText;
    public Text highScoreText;

    public void PlayGame()
    {
        SceneManager.LoadScene("EndlessLevel");
        Time.timeScale = 1;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");

    }

    public void OpenSettings()
    {
        SceneManager.LoadScene("Settings");

    }

    public void OpenGarage()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Garage");

    }

    public void OpenShop()
    {
        SceneManager.LoadScene("Shop");

    }

    public void OpenStats()
    {
        SceneManager.LoadScene("Stats");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResetHighScore()
    {
        PlayerPrefs.SetInt("HighScore", 0);

    }
    public void ResetCoins()
    {
        PlayerPrefs.SetInt("Coins", 0);

    }

    void Update()
    {
        highScoreText.text = "Highscore: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        coinText.text = "Coins: " + PlayerPrefs.GetInt("Coins", 0).ToString();
    }
}
