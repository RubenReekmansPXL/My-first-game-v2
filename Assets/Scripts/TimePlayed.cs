using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimePlayed : MonoBehaviour
{
    // Start is called before the first frame update

    private float seconds;
    private float minutes;
    private float playtime;
    private float timesPlayed;
    private int averageScore;
    private int totalCoins;
    public Text playtimeText;
    public Text timesPlayedText;
    public Text totalCoinsText;
    public Text AverageScoreText;

   void Start()
    {
        seconds = 0;
        minutes = 0;
        playtime = PlayerPrefs.GetFloat("PlayTime");

        playtimeText.text = playtime.ToString();


    }

    public void Update()
    {
        playtime = PlayerPrefs.GetFloat("PlayTime");
        playtimeText.text = playtime.ToString();

        timesPlayed = PlayerPrefs.GetInt("TimesPlayed", 0);
        timesPlayedText.text = timesPlayed.ToString();
        
        totalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
        totalCoinsText.text = totalCoins.ToString();

        averageScore = PlayerPrefs.GetInt("AverageScore", 0);
        AverageScoreText.text = averageScore.ToString();


    }
    void SavePlayTime()
    {
        seconds = Time.realtimeSinceStartup;
        minutes = (int) (seconds / 60);
        playtime += minutes;
        PlayerPrefs.SetFloat("PlayTime", playtime);
    }

    private void OnApplicationQuit()
    {
        SavePlayTime();
    }
}
