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
    private readonly string mainMenu = "Main Menu";

    // Start is called before the first frame update
    void Start()
    {
        //player1ScoreText = GetComponent<TextMeshPro>();
        //player2ScoreText = GetComponent<TextMeshPro>();
    }

    public void ReturnToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(mainMenu);
    }
}
