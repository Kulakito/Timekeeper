using UnityEngine;

public abstract class Trigger : MonoBehaviour
{
    public abstract void TriggerObject(bool active);
}

public class Door : Trigger
{
    private Animator animator;
    private BoxCollider2D doorCollider;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        doorCollider = GetComponent<BoxCollider2D>();
    }

    public override void TriggerObject(bool active)
    {
        animator.SetBool("Activated", active);
        doorCollider.enabled = !active;
    }
}
