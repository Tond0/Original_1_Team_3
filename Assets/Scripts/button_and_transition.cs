using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button_and_transition : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Replay()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOn()
    {
        UIManager.instance.IniziaGioco();
    }

    public void Seppuku()
    {
        Destroy(transform.parent.gameObject);
    }
}
