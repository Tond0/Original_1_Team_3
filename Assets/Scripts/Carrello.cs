using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrello : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<GameInfo>(out GameInfo gioco))
        {
            int tempoDaVariare = 0;
            //Sergiu daje roma tocca a te qua.
            switch (gioco.rarity)
            {
                case Rarity.Comune:
                    tempoDaVariare = gioco.originale == true ? 2 : -1;
                    break;

                case Rarity.Raro:
                    tempoDaVariare = gioco.originale == true ? 3 : -2;
                    break;

                case Rarity.Epico:
                    tempoDaVariare = gioco.originale == true ? 4 : -3;
                    break;

                case Rarity.Leggendario:
                    tempoDaVariare = gioco.originale == true ? 6 : -5;
                    break;
            }

            GameManager.instance.AlteraTimerGioco(tempoDaVariare);

            Destroy(gioco.transform.parent.gameObject);
        }
    }
}