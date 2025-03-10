using UnityEngine;
using UnityEngine.InputSystem;

namespace Cainos.PixelArtTopDown_Basic
{
    public class TopDownCharacterController : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float speed;
        private Vector2 direction;

        private Animator animator;
        private Rigidbody2D rb;

        [Header("Interact")]
        [SerializeField] private float radius = 1;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>();

            animator.SetFloat("DirX", 0);
            animator.SetFloat("DirY", -1);
        }

        private void Update()
        {
            direction.Normalize();
            animator.SetBool("IsMoving", direction.magnitude > 0);

            if (direction.magnitude > 0) 
            {
                animator.SetFloat("DirX", direction.x);
                animator.SetFloat("DirY", direction.y);
            }

            rb.linearVelocity = speed * direction;
        }

        private void OnMove(InputValue movementValue)
        {
            direction = movementValue.Get<Vector2>();
        }

        private void OnInteract()
        {
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, radius);
            foreach (Collider2D collider in hitColliders)
            {
                if (collider.TryGetComponent(out IInteractableObject interactableObject))
                {
                    interactableObject.InteractWith();
                }
            }
        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}
