using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverMenu;
    [HideInInspector]
    public bool gameEnded;

    // Start is called before the first frame update
    void Start()
    {
        gameOverMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameEnded)
            gameOverMenu.SetActive(true);
        else
            gameOverMenu.SetActive(false);
    }
}
