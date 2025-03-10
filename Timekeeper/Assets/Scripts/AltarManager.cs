using System;
using UnityEngine;

public class AltarManager : Puzzle
{
    private int colliderCount;

    public event Action<bool> OnCollisionEvent;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (triggerList != null && colliderCount == 0) ReturnToCheckPuzzles(true);
        colliderCount++;
        OnCollisionEvent?.Invoke(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        colliderCount--;
        if (colliderCount == 0) 
        {
            OnCollisionEvent?.Invoke(false);
            if (triggerList != null) ReturnToCheckPuzzles(false);
        }
    }
}
