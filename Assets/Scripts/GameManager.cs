using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour
{
    private GameObject playerOne;
    private GameObject playerTwo;

    public bool gameOver = false; 

    // Start is called before the first frame update
    void Start()
    {
        playerOne = GameObject.FindGameObjectWithTag("Player1");
        playerTwo = GameObject.FindGameObjectWithTag("Player2");
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
            //Add a screen that informs players the game is over. 
        SceneManager.LoadScene("GameOver"); 
    }
}
