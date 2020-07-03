using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControls : MonoBehaviour {

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void StartEasy()
    {
        SnakeControls.SnakeSpeed = 0.7f;
        SceneManager.LoadScene("GameScene");
    }

    public void StartMedium()
    {
        SnakeControls.SnakeSpeed = 0.3f;
        SceneManager.LoadScene("GameScene");
    }

    public void StartHard()
    {
        SnakeControls.SnakeSpeed = 0.1f;
        SceneManager.LoadScene("GameScene");
    }
}
