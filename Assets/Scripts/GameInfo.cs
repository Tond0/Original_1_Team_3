using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class GameInfo : MonoBehaviour
{

    [Header("Game Stats")]

    public string nome;
    public Rarity rarity;
    public bool originale;
    private Vector3 startPos;
    private Vector3 startRot;
    public Vector3 destination;
    public Vector3 rotDest;
    [SerializeField] bool interactable;
    [SerializeField] AnimationCurve moveToDest;
    [SerializeField] AnimationCurve rotToDest;
    [SerializeField] LayerMask whereToLand;
    [SerializeField] GameObject pacco;

    [SerializeField] private float durataVita;
    [SerializeField] private float durataTransizione;
    private float timeRemainingTransizione = 0;
    private float timeRemainingVita = 0;

    public AudioSource audioSource;


    [SerializeField]private bool pickedUp;
    private TextMeshProUGUI txtDisplay;
    // Start is called before the first frame update
    void Start()
    {
        txtDisplay = GetComponentInChildren<TextMeshProUGUI>();
        txtDisplay.text = nome;

        startPos = transform.position;
        startRot = pacco.transform.eulerAngles;
        audioSource= GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interactable)
        {
            if (pickedUp)
            {
                transform.localPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 60));
            }
        }

        if (timeRemainingVita < durataVita)
            timeRemainingVita += Time.deltaTime;
        else
            Destroy(gameObject);

        MoveGameToDest();
    }

    public void DoPickedUp()
    {
        pickedUp = true;
        audioSource.Play();
    }

    public void GameReleased()
    {
        Ray castPoint = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(castPoint, out RaycastHit hit, 200, whereToLand))
            destination = hit.point;

        startPos = transform.position;
        interactable = false;
        timeRemainingTransizione = 0;
        pickedUp = false;
    }

    void MoveGameToDest()
    {
        float t = timeRemainingTransizione / durataTransizione;
        float ease = moveToDest.Evaluate(t);
        float rotEase = rotToDest.Evaluate(t);

        if (!interactable)
        {
            transform.position = Vector3.Lerp(startPos, destination, ease);
            pacco.transform.eulerAngles = Vector3.Lerp(startRot, rotDest, rotEase);
            timeRemainingTransizione += Time.deltaTime;
        }


        if (Vector3.Distance(pacco.transform.position, destination) < 0.1f)
        {
            interactable = true;
        }
    }
}



