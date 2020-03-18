using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverMenu;
    public TextMeshProUGUI player1ScoreText;
    public TextMeshProUGUI player2ScoreText;
    [HideInInspector]
    public bool gameEnded = false;
    [HideInInspector]
    public int player1CheckScore, player2CheckScore;
    private int currentHighscore = 0;
    private ReadWriteText readWriteText;
    private readonly string mainMenu = "Main Menu";

    // Start is called before the first frame update
    void Start()
    {
        readWriteText = GetComponent<ReadWriteText>();
        currentHighscore = readWriteText.highScore;
        //player1ScoreText = GetComponent<TextMeshPro>();
        //player2ScoreText = GetComponent<TextMeshPro>();

    }

    void Update()
    {
        if (gameEnded)
        {
            if (player1CheckScore > player2CheckScore)
            {
                if (player1CheckScore > currentHighscore)
                {
                    currentHighscore = player1CheckScore;
                    readWriteText.highScore = currentHighscore;
                    readWriteText.OverwriteData();
                }
            }
            else if (player2CheckScore > player1CheckScore)
            {
                if (player2CheckScore > currentHighscore)
                {
                    currentHighscore = player2CheckScore;
                    readWriteText.highScore = currentHighscore;
                    readWriteText.OverwriteData();
                }
            }
        }
    }

    public void ReturnToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(mainMenu);
    }
}
