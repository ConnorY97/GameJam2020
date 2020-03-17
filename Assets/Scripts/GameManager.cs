using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour
{
    private GameObject playerOne;
    private GameObject playerTwo;
    private GameOverMenu gameOverMenu;

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
