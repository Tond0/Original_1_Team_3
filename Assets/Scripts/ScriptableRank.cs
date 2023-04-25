using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Posizione")]
public class ScriptableRank : ScriptableObject, IComparable<ScriptableRank>
{
    public string nome;
    public int punteggio;

    public int CompareTo(ScriptableRank rank)
    {
        var a = this;
        var b = rank as ScriptableRank;

        if (a.punteggio < b.punteggio)
            return 1;

        if (a.punteggio > b.punteggio)
            return -1;

        return 0;
    }
}
