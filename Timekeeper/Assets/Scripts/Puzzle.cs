using System.Collections.Generic;
using UnityEngine;

public abstract class Puzzle : MonoBehaviour
{
    protected List<Trigger> triggerList = new();

    protected PuzzleManager puzzleManager;

    protected void Start()
    {
        puzzleManager = FindAnyObjectByType<PuzzleManager>();
    }

    protected void ReturnToCheckPuzzles(bool solved)
    {
        foreach (Trigger trigger in triggerList)
        {
            puzzleManager.CheckSolvedPuzzle(trigger, solved);
        }
    }

    public void AddPuzzleTrigger(Trigger trigger)
    {
        triggerList.Add(trigger);
    }
}
