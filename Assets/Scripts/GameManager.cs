using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private GameObject playerOne;
    private GameObject playerTwo;
    private GameOverMenu gameOverMenu;

    //public Text playerOneScore;
    //public Text playerTwoScore;

    private int p1Score = 0;
    private int p2Score = 0;

    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        playerOne = GameObject.FindGameObjectWithTag("Player1");
        playerTwo = GameObject.FindGameObjectWithTag("Player2");
        gameOverMenu = FindObjectOfType<GameOverMenu>();
        var temp = FindObjectsOfType<GameOverMenu>();
        gameOverMenu.gameOverMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerOne.activeInHierarchy == false && playerTwo.activeInHierarchy == false)
            gameOver = true;

        p1Score = (int)playerOne.transform.position.y;
        p2Score = (int)playerTwo.transform.position.y;

        //playerOneScore.text = p1Score.ToString();
        //playerTwoScore.text = p2Score.ToString();

        if (gameOver && !gameOverMenu.gameEnded)
            GameOver();

    }

    public void GameOver()
    {
        //This is when you add code to save 
        Debug.Log(p1Score);
        Debug.Log(p2Score);

        gameOverMenu.gameEnded = true;
        gameOverMenu.gameOverMenu.SetActive(true);
        Debug.Log("GameOVER");
        gameOverMenu.player1ScoreText.SetText(p1Score.ToString());
        gameOverMenu.player2ScoreText.SetText(p2Score.ToString());
    }
}
