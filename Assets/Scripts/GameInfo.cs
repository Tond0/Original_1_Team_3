using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class GameInfo : MonoBehaviour
{
    public string nome;
    public Rarity rarity;
    public bool originale;

    private bool pickedUp;
    private TextMeshProUGUI txtDisplay;
    // Start is called before the first frame update
    void Start()
    {
        txtDisplay = GetComponentInChildren<TextMeshProUGUI>();
        txtDisplay.text = nome;   
    }

    // Update is called once per frame
    void Update()
    {
        if (pickedUp)
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5));
    }

    public void DoPickedUp()
    {
        pickedUp = !pickedUp;
    }
}
