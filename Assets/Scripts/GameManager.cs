
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject pausePanel;

    public float restartDelay;
    public static bool gameOver;
    public static bool gameIsPaused;
    public GameObject gameOverPanel;
    public static bool isGameStarted;
    public GameObject tapButton;
    public GameObject pauseButton;
    public Text coinsText;

    public Animator l_Animator;
    public Animator r_Animator;

    public GameObject l;
    public GameObject r;
    public Image lImage;
    public Image rImage;

    public static int numberOfCoins;

    void Start()
    {
        gameOver = false;
        gameIsPaused = false;
        isGameStarted = false;
        numberOfCoins = PlayerPrefs.GetInt("Coins", 0);
        pauseButton.SetActive(true);
    }

    void Update()
    {
        if (gameIsPaused)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
            gameIsPaused = true;
            pauseButton.SetActive(false);
        }

        if (gameOver)
        {
            Invoke("gameOverShow", restartDelay);

        }
        coinsText.text = numberOfCoins.ToString();

        if (MovingManager.tap)
        {
            l_Animator.GetComponent<Animator>().enabled = false;
            r_Animator.GetComponent<Animator>().enabled = false;

            isGameStarted = true;
            tapButton.SetActive(false);
            lImage.enabled = true;
            rImage.enabled = true;

            l.SetActive(false);
            r.SetActive(false);


        }
        
    }

    public void pauzeGame()
    {
        gameIsPaused = true;
    }

    public void resumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
        pauseButton.SetActive(true);

    }

    public void gameOverShow()
    {
        gameOverPanel.SetActive(true);
        pausePanel.SetActive(false);
        pauseButton.SetActive(false);
    }

}
