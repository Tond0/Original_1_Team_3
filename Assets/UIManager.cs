using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject menu_principale;
    public GameObject menu_finale;
    public GameObject game_UI;

    public SpawnGiochi spawn;

    public void Start()
    {
        spawn.enabled = false;

        menu_principale.SetActive(true);
        game_UI.SetActive(false);
        menu_finale.SetActive(false);
    }

    public void IniziaGioco()
    {
        menu_principale.SetActive(false);
        game_UI.SetActive(true);
        spawn.enabled = true;
    }

    public void FinisceGioco()
    {
        game_UI.SetActive(false);
        menu_finale.SetActive(true);

        spawn.enabled = false;
    }
}
