using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;
using UnityEngine.Android;

public class RankPlacement : MonoBehaviour
{
    // Start is called before the first frame update
    private ScriptableRank[] concorrenti;
    public GameObject rankTile;
    public Transform snap;
    public float offsets;

    void Start()
    {
        //Tutti le posizioni create vengono prese dal folder
        //Non molto sicuro ma fatto perché stare a spiegare ad ogni artist dove trascinare cosa era troppo difficile.
        concorrenti = Resources.LoadAll<ScriptableRank>("Scriptable/Posizioni");

        Array.Sort(concorrenti);
        SpawnClassifica();
    }

    private void SpawnClassifica()
    {
        int i = 0;
        foreach (ScriptableRank rank in concorrenti)
        {
            Tile posSpawnata = Instantiate(rankTile, snap.transform, false).GetComponent<Tile>();
            posSpawnata.transform.localPosition += new Vector3(0, i * -offsets, 0);
            posSpawnata.posizione.text = i + 1 + "°";
            posSpawnata.nome.text = rank.nome;
            posSpawnata.punteggio.text = rank.punteggio.ToString();
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
