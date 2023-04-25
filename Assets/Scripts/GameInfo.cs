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

    [SerializeField] private float durata;
    private float timeRemaining = 0;





    private bool pickedUp;
    private TextMeshProUGUI txtDisplay;
    // Start is called before the first frame update
    void Start()
    {
        txtDisplay = GetComponentInChildren<TextMeshProUGUI>();
        txtDisplay.text = nome;

        startPos = transform.position;
        startRot = pacco.transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (interactable)
        {
            if (pickedUp)
                transform.localPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 60));
        }

        MoveGameToDest();
    }

    public void DoPickedUp()
    {
        pickedUp = !pickedUp;
    }

    public void GameReleased()
    {
        Ray castPoint = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(castPoint, out RaycastHit hit, 200, whereToLand))
        {
            destination = hit.point;
            startPos = transform.position;
            interactable = false;
            timeRemaining = 0;
            DoPickedUp();
        }
    }

    void MoveGameToDest()
    {
        float t = timeRemaining / durata;
        float ease = moveToDest.Evaluate(t);
        float rotEase = rotToDest.Evaluate(t);

        if (!interactable)
        {
            transform.position = Vector3.Lerp(startPos, destination, ease);
            pacco.transform.eulerAngles = Vector3.Lerp(startRot, rotDest, rotEase);
            timeRemaining += Time.deltaTime;
        }


        if (Vector3.Distance(pacco.transform.position, destination) < 0.1f)
        {
            interactable = true;
        }
    }
}



