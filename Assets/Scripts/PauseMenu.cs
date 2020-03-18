using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public Slider volumeSlider;
    ReadWriteText readWrite;
    private GameOverMenu gameOver;
    private readonly string mainMenu = "Main Menu";

    bool Paused;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        Cursor.visible = false;
        Time.timeScale = 1f;
        readWrite = GetComponent<ReadWriteText>();
        volumeSlider.value = readWrite.volume;
        gameOver = FindObjectOfType<GameOverMenu>().GetComponent<GameOverMenu>();
        //gameData = GetComponent<ReadWriteText.GameData>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !gameOver.gameEnded)
        {
            Pause();
        }
    }

    public void Pause()
    {
        if (Paused)
        {
            Debug.Log("Game Unpaused");
            Paused = false;
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
            readWrite.volume = volumeSlider.value;
            readWrite.OverwriteData();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Debug.Log("Game Paused");
            Paused = true;
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void ResumeGame()
    {
        Pause();
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        UnityEngine.SceneManagement.SceneManager.LoadScene(mainMenu);
    }
}
