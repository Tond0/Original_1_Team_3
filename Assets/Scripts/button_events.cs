using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button_events : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Replay()
    {
        SceneManager.LoadScene(0);
    }
}
