using Cainos.PixelArtTopDown_Basic;
using System;
using System.Collections.Generic;
using UnityEngine;

public class RuneManager : Puzzle
{
    [SerializeField] private SpriteRenderer[] runeStonesOrder;
    private List<SpriteRenderer> runeStonesCurOrder = new();

    public void ToggleRune(SpriteRenderer glowObject)
    {
        if (glowObject.gameObject.activeSelf)
        {
            runeStonesCurOrder.Add(glowObject);
        }
        else 
        {
            runeStonesCurOrder.Remove(glowObject);
        }

        if (runeStonesCurOrder.Count == runeStonesOrder.Length)
        {
            CheckRuneStoneOrder();
        }
    }

    private void CheckRuneStoneOrder()
    {
        for (int i = 0; i < runeStonesOrder.Length; i++)
        {
            if (runeStonesOrder[i].color != runeStonesCurOrder[i].color)
            {
                foreach (SpriteRenderer rune in runeStonesOrder)
                {
                    rune.gameObject.SetActive(false);
                }
                runeStonesCurOrder.Clear();
                return;
            }
        }
        ReturnToCheckPuzzles(true);
    }
}
