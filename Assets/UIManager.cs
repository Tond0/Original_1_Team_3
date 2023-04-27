using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject menu_principale;
    public GameObject menu_finale;
    public GameObject game_UI;

    public SpawnGiochi spawn;
    public TextMeshProUGUI timerTxt;
    public TextMeshProUGUI punteggioTxt;

    public Texture2D manoAperta;
    public Texture2D manoChiusa;

    public static UIManager instance;

    public void Awake()
    {
        if(instance != null)
            Destroy(this);
        else
            instance = this;
    }

    public void Start()
    {
        spawn.enabled = false;

        menu_principale.SetActive(true);
        game_UI.SetActive(false);
        menu_finale.SetActive(false);
    }

    private void Update()
    {
        MouseTextureChanger();
    }

    public void MouseTextureChanger()
    {
        if (Input.GetMouseButton(0))
            Cursor.SetCursor(manoChiusa, new Vector2(manoAperta.width / 2, manoAperta.height / 2), CursorMode.ForceSoftware);
        else
            Cursor.SetCursor(manoAperta, new Vector2(manoAperta.width / 2, manoAperta.height / 2), CursorMode.ForceSoftware);

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

    public void TimerText(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        timerTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void PunteggioText(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        int punteggio = (int)time;
        punteggioTxt.text = punteggio.ToString();
    }
}
