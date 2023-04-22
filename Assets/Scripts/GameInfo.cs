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
    public Vector3 destination;
    bool interactable;
    [SerializeField] AnimationCurve moveToDest;







    private bool pickedUp;
    private TextMeshProUGUI txtDisplay;
    // Start is called before the first frame update
    void Start()
    {
        txtDisplay = GetComponentInChildren<TextMeshProUGUI>();
        txtDisplay.text = nome;

        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (interactable)
        {
            if (pickedUp)
                transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5));
        }

        MoveGameToDest();

    }

    public void DoPickedUp()
    {
        pickedUp = !pickedUp;
    }

    void MoveGameToDest()
    {

        if (!interactable)
        {
            transform.position = Vector3.Lerp(startPos, destination, moveToDest.Evaluate(Time.deltaTime * 0.001f));
        }


        if (transform.position == destination)
        {
            interactable = true;
        }
    }


}



