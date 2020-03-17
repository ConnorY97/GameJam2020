using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public Slider volumeSlider;
    ReadWriteText.GameData gameData;
    ReadWriteText readWrite;

    // Start is called before the first frame update
    void Start() 
    {
        //gameData = new ReadWriteText.GameData();
        readWrite = GetComponent<ReadWriteText>();
    }

    private void LateUpdate()
    {
        volumeSlider.value = readWrite.volume;
    }

    public void PlayGame()
    {
        Debug.Log("PLAYING GAME");
        SceneManager.LoadScene("SampleScene");
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

