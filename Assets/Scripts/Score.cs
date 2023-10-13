using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;
    public Text highScoreText;
    public List<int> finalscore = new List<int>();


    public GameObject carholder;
    public int index;

    private int totalScore;
    private int averageScore;
    private int totalPlays;

    private bool OnceDone;


    // Update is called once per frame
    private void Start()
    {
        highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        totalPlays = PlayerPrefs.GetInt("TimesPlayed", 0);
        totalScore = PlayerPrefs.GetInt("TotalScore", 0);
        OnceDone = false;
    }
    void Update()
    {
        index = PlayerPrefs.GetInt("CharacterSelected");
        player = carholder.transform.GetChild(index);
        int score = Convert.ToInt32(player.position.z) / 20;
        scoreText.text = score.ToString();
        if(score > PlayerPrefs.GetInt("HighScore", 0) && !GameManager.gameOver)
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text = score.ToString();
        }
 

        if (GameManager.gameOver)
        {
            finalscore.Add(score);
            int finalScoreOnDie = finalscore[0];
            if(OnceDone == false)
            {
                totalScore += finalScoreOnDie;
                PlayerPrefs.SetInt("TotalScore", totalScore);
                if (totalPlays != 0)
                {
                    averageScore = totalScore / (totalPlays + 1);
                    PlayerPrefs.SetInt("AverageScore", averageScore);
                }
                OnceDone = true;
            }
            scoreText.text = finalScoreOnDie.ToString();
            if (finalScoreOnDie > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", finalScoreOnDie);
                highScoreText.text = finalScoreOnDie.ToString();
            }
        }
    }
}
