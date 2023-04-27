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


    [Header("Liste Giochi")]
    [SerializeField] List<ScriptableGioco> commonGamesList;
    [SerializeField] List<ScriptableGioco> rareGamesList;
    [SerializeField] List<ScriptableGioco> epickGamesList;
    [SerializeField] List<ScriptableGioco> legendaryGamesList;


    [Header("Materiali Rarita")]
    [SerializeField] Material commonMterial;
    [SerializeField] Material rareMaterial;
    [SerializeField] Material epicMaterial;
    [SerializeField] Material legendaryMaterial;


    [Header("Probabilita Rarita")]
    [SerializeField][Range(1, 100)] int commonProbability;
    [SerializeField][Range(1, 100)] int rareProbability;
    [SerializeField][Range(1, 100)] int epickProbability;
    [SerializeField][Range(1, 100)] int legendariProbabiliti;

    int commonPercentage;
    int rarePercentage;
    int epickPercentage;
    int legendaryPercentage;


    [Header("Numero minimo di giochi spownabili per rarita")]
    [SerializeField] int minCommonSpawns;
    [SerializeField] int minRareSpawns;
    [SerializeField] int minEpickSpawns;
    [SerializeField] int minLegendarySapwns;




    [Header("Tempo do spawn fra giochi")]
    [SerializeField] int time1;
    [SerializeField] int time2;
    [SerializeField] int time3;
    [SerializeField] int time4;
    [SerializeField] int time5;
    [SerializeField] int time6;


    [Header("Tempo do spawn fra giochi")]
    [SerializeField] int minGameRange1;
    [SerializeField] int MaxGameRange1;


    float spawnTimer;

    [SerializeField] GameObject box;

    bool vero = true;
    bool falso = false;



    private void Start()
    {
        commonPercentage = commonProbability;
        rarePercentage = commonProbability + rareProbability;
        epickPercentage = commonProbability + rareProbability + epickProbability;
        legendaryPercentage = commonProbability + rareProbability + epickProbability + legendariProbabiliti;
    }



    private void Update()
    {
        if (spawnTimer > 0)
        {
            spawnTimer -= Time.deltaTime;
        }
        else
        {

            int randomGamesNumber = Random.Range(minGameRange1, MaxGameRange1 + 1);



            while (randomGamesNumber > 0)
            {

                int rarityPercentage = Random.Range(1, 101);

                if (rarityPercentage <= commonPercentage)
                {
                    spawnGroup(commonGamesList, minCommonSpawns, commonMterial);
                }
                else if (rarityPercentage > commonPercentage && rarityPercentage <= rarePercentage)
                {
                    spawnGroup(rareGamesList, minRareSpawns, rareMaterial);
                }
                else if (rarityPercentage > rarePercentage && rarityPercentage <= epickPercentage)
                {
                    spawnGroup(epickGamesList, minEpickSpawns, epicMaterial);
                }
                else if (rarityPercentage > epickPercentage && rarityPercentage <= legendaryPercentage)
                {
                    spawnGroup(legendaryGamesList, minLegendarySapwns, legendaryMaterial);
                }

                randomGamesNumber--;
            }

            spawnTimer = time1;
        }

    }



    void spawnGroup(List<ScriptableGioco> gamesList, int MinSpownableNumber, Material rarityMaterial)
    {


        int gameRNG = Random.Range(0, gamesList.Count - 1);
        int GamesNumber = gamesList[gameRNG].nomi_falsi.Length;
        int spawnableNumber = Random.Range(MinSpownableNumber, GamesNumber + 1);




        GameObject tmp = Instantiate(new GameObject());
        tmp.name = gamesList[gameRNG].nome_gioco + " Folder";

        for (int i = 0; i < spawnableNumber; i++)
        {
            if (i == 0)
            {
                spawnGame(box, gamesList[gameRNG].nome_gioco, tmp.transform, vero, rarityMaterial);
            }
            else
            {
                spawnGame(box, gamesList[gameRNG].nomi_falsi[i], tmp.transform, falso, rarityMaterial);
            }
        }


    }




    void spawnGame(GameObject Box, string name, Transform Folder, bool Validity, Material rarityMaterial)
    {
        float Xrange = Random.Range(limitA.position.x, limitB.position.x);
        float Zrange = Random.Range(limitA.position.z, limitB.position.z);
        float rotRange = Random.Range(360, 720);

        Vector3 spawn = new Vector3(Xrange, 0.5f, 200);
        Vector3 Destination = new Vector3(Xrange, 0.5f, Zrange);
        Vector3 rotDest = new Vector3(90, rotRange, 0);


        GameObject tmp = Instantiate(Box, spawn, Quaternion.identity, Folder);

        GameInfo game = tmp.GetComponent<GameInfo>();
        MeshRenderer meshRenderer = tmp.GetComponentInChildren<MeshRenderer>();
        game.destination = Destination;
        game.name = name;
        game.nome = name;
        game.originale = Validity;
        game.rotDest = rotDest;
        meshRenderer.material = rarityMaterial;
    }




}

