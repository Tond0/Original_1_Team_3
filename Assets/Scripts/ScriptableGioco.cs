using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Rarity { Comune, Raro, Epico, Leggendario };

[CreateAssetMenu(menuName = "Gioco")]
public class ScriptableGioco : UnityEngine.ScriptableObject
{
    public string nome_gioco;
    public Rarity rarity;
    public string[] nomi_falsi;
}
