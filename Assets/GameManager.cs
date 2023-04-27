using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float tempo_gioco;
    private float punteggio;

    public static GameManager instance;

    public void Awake()
    {
        if(instance != null)
            Destroy(this);
        else
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        tempo_gioco *= 60;
    }

    // Update is called once per frame
    void Update()
    {
        tempo_gioco -= Time.deltaTime;
        UIManager.instance.TimerText(tempo_gioco);

        punteggio += Time.deltaTime;
        UIManager.instance.PunteggioText(punteggio);

        if (tempo_gioco < 0)
            UIManager.instance.FinisceGioco();
    }

    public void AlteraTimerGioco(int alterazioneTempo)
    {
        tempo_gioco += alterazioneTempo;
    }
}
