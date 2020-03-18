using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuButtons : MonoBehaviour
{
    public Slider volumeSlider;
    public string levelName;
    public TextMeshProUGUI highScore;
    ReadWriteText readWrite;

    // Start is called before the first frame update
    void Start() 
    {
        //gameData = new ReadWriteText.GameData();
        readWrite = GetComponent<ReadWriteText>();
        highScore.SetText(readWrite.highScore.ToString());
    }

    private void LateUpdate()
    {
        volumeSlider.value = readWrite.volume;
    }

    public void PlayGame()
    {
        Debug.Log("PLAYING GAME");
        SceneManager.LoadScene(levelName);
    }

    public void SaveValues()
    {
        readWrite.volume = volumeSlider.value;
        readWrite.OverwriteData();
    }

    public void QuitGame()
    {
        readWrite.volume = volumeSlider.value;
        //gameData.highScore = highScore;
        readWrite.OverwriteData();
        Debug.Log("QUIT");
        Application.Quit();
        UnityEditor.EditorApplication.ExitPlaymode();
    }
}

