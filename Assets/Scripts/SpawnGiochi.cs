using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering;

public class SpawnGiochi : MonoBehaviour
{

    [Header("Table Limits")]
    [SerializeField] Transform limitA;
    [SerializeField] Transform limitB;

    [Header("Lista Giochi")]
    [SerializeField] List<ScriptableGioco> gamesList;

    [Header("Time Between Spawns")]
    [SerializeField] int maxTime;
    [SerializeField] int minTime;
    float spawnTimer;

    [SerializeField] GameObject box;

    bool vero = true;
    bool falso = false;




    private void Update()
    {
        spawnGroup();
    }



    void spawnGroup()
    {
        if(spawnTimer > 0)
        {
            spawnTimer -= Time.deltaTime;
        }
        else
        {

           int gameRNG = Random.Range(0, gamesList.Count - 1);
           int GamesNumber = gamesList[gameRNG].nomi_falsi.Length;


            GameObject tmp = Instantiate(new GameObject());
            tmp.name = gamesList[gameRNG].nome_gioco + "Folder";

            for (int i = 0; i < GamesNumber; i++)
            {
                if(i == 0)
                {
                    spawnGame(box, gamesList[gameRNG].nome_gioco, tmp.transform ,vero);
                }
                else
                {
                    spawnGame(box, gamesList[gameRNG].nomi_falsi[i], tmp.transform, falso);
                }
            }


            spawnTimer = Random.Range(minTime, maxTime);
        }
    }




    void spawnGame(GameObject Box, string name, Transform Folder, bool Validity)
    {
        float Xrange = Random.Range(limitA.position.x, limitB.position.x);
        float Zrange = Random.Range(limitA.position.z, limitB.position.z);

        Vector3 spawn = new Vector3(Xrange, 0.5f, 200);
        Vector3 Destination =  new Vector3(Xrange,0.5f,Zrange);

        GameObject tmp = Instantiate(Box, spawn, Quaternion.identity, Folder);

        GameInfo game = tmp.GetComponent<GameInfo>();
        game.destination = Destination;
        game.name = name;
        game.nome = name;
        game.originale = Validity;
    }




}

