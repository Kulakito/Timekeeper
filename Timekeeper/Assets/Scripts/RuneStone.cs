using System;
using UnityEngine;

public class RuneStone : MonoBehaviour, IInteractableObject
{
    [SerializeField] private GameObject glowObject;

    private RuneManager runeManager;

    private void Start()
    {
        runeManager = GetComponentInParent<RuneManager>();
    }

    public void InteractWith()
    {
        glowObject.SetActive(!glowObject.activeSelf);
        runeManager.ToggleRune(glowObject.GetComponent<SpriteRenderer>());
    }
}
