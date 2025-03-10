using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class PuzzlesTrigger
{
    [field: SerializeField] public Trigger Trigger { get; private set; }
    [SerializeField] private Puzzle[] puzzles;
    private int solvedPuzzlesCount;

    public void IncrementSolvedPuzzles(bool solved)
    {
        solvedPuzzlesCount = solved ? solvedPuzzlesCount + 1 : solvedPuzzlesCount - 1;
        Trigger.TriggerObject(solvedPuzzlesCount == puzzles.Length);
    }

    public void SetTriggersToPuzzles()
    {
        foreach (var puzzle in puzzles)
        {
            puzzle.AddPuzzleTrigger(Trigger);
        }
    }
}

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private PuzzlesTrigger[] puzzlesTriggers;
    private Dictionary<Trigger, PuzzlesTrigger> puzzlesTriggersDict;

    private void Start()
    {
        foreach (var puzzleComplect in puzzlesTriggers)
        {
            puzzleComplect.SetTriggersToPuzzles();
        }
        puzzlesTriggersDict = puzzlesTriggers.ToDictionary(key => key.Trigger, element => element);
    }

    public void CheckSolvedPuzzle(Trigger key, bool solved)
    {
        puzzlesTriggersDict[key].IncrementSolvedPuzzles(solved);
    }
}
