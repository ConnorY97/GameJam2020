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

    public Text playerOneScore;
    public Text playerTwoScore;

    private int p1Score;
    private int p2Score; 

    public bool gameOver = false; 

    // Start is called before the first frame update
    void Start()
    {
        playerOne = GameObject.FindGameObjectWithTag("Player1");
        playerTwo = GameObject.FindGameObjectWithTag("Player2");
        gameOverMenu = FindObjectOfType<GameOverMenu>().GetComponent<GameOverMenu>();
        gameOverMenu.gameEnded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerOne.activeInHierarchy == false && playerTwo.activeInHierarchy == false)
            gameOver = true;

        p1Score = (int)playerOne.transform.position.y;
        p2Score = (int)playerTwo.transform.position.y;

        playerOneScore.text = p1Score.ToString();
        playerTwoScore.text = p2Score.ToString(); 

        if (gameOver)
            GameOver(); 
    }

    public void GameOver()
    {
        //This is when you add code to save 
        Debug.Log(p1Score);
        Debug.Log(p2Score); 
        gameOverMenu.gameEnded = true;
    }
}
