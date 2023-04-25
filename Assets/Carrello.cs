using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrello : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<GameInfo>(out GameInfo gioco))
        {
            //Sergiu daje roma tocca a te qua.
            //score = gioco.originale ? score + 1 : score - 2;
            Destroy(gioco.transform.parent.gameObject);
        }
    }
}
