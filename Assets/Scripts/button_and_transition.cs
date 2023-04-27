using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button_and_transition : MonoBehaviour
{
    public AudioSource audioSource;
    public float delay = 2.0f;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        audioSource.Play();
    }
    public void QuitGame()
    {
        Invoke( "QuitGame2()", delay) ;
    }

    public void Replay()
    {
        Invoke("Replay2", delay);
    }

    public void GameOn()
    {
        Invoke("GameOn2", delay);
    }

    public void Seppuku()
    {
        Invoke("Seppuku2", delay);
    }

    public void QuitGame2()
    {
        Application.Quit();
    }

    public void Replay2()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOn2()
    {
        UIManager.instance.IniziaGioco();
    }

    public void Seppuku2()
    {
        Destroy(transform.parent.gameObject);
    }
}
