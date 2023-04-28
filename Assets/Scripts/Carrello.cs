using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrello : MonoBehaviour
{
    public AudioSource audioSource;

    private void Start()
    {
        audioSource= GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<GameInfo>(out GameInfo gioco))
        {
            int tempoDaVariare = 0;
            //Sergiu daje roma tocca a te qua.
            switch (gioco.rarity)
            {
                case Rarity.Comune:
                    tempoDaVariare = gioco.originale == true ? 4 : -2;

                    break;

                case Rarity.Raro:
                    tempoDaVariare = gioco.originale == true ? 5 : -3;
                    break;

                case Rarity.Epico:
                    tempoDaVariare = gioco.originale == true ? 6 : -4;
                    break;

                case Rarity.Leggendario:
                    tempoDaVariare = gioco.originale == true ? 8 : -6;
                    break;
            }

            GameManager.instance.AlteraTimerGioco(tempoDaVariare);

            Destroy(gioco.transform.parent.gameObject);
            audioSource.Play();
        }
    }
}
