using UnityEngine.InputSystem;
using UnityEngine;
using System.Collections;

public class PlayerMovementController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    private Vector2 curMovementInput;

    [Header("Rush")]
    public float rushDuration;
    public float rushSpeed;
    public float rushCost;
    private Coroutine rushCoroutine;
    private bool isRushing;

    [Header("Jump")]
    public float jumpForce;
    public float jumpCost;
    public LayerMask groundLayerMask;

    private Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            curMovementInput = context.ReadValue<Vector2>();
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = Vector2.zero;
        }
    }

    private void Move()
    {
        if (!IsGrounded())
        {
            return;
        }
        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
        dir *= moveSpeed;
        dir.y = rigidbody.velocity.y;
        rigidbody.velocity = dir;
    }

    public void OnRushInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            if (!isRushing && CharacterManager.Instance.Player.Condition.UseStamina(rushCost)) 
            {
                rushCoroutine = StartCoroutine(Rush());
            }
        }
    }

    IEnumerator Rush()
    {
        isRushing = true;
        moveSpeed += rushSpeed;
        yield return new WaitForSecondsRealtime(rushDuration);
        isRushing = false;
        moveSpeed -= rushSpeed;
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && IsGrounded() && CharacterManager.Instance.Player.Condition.UseStamina(jumpCost))
        {
            rigidbody.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
        }
    }

    public void JumpForward(float force)
    {
        rigidbody.AddForce((Vector2.up + (Vector2)transform.forward) * force, ForceMode.Impulse);
    }

    bool IsGrounded()
    {
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.right * 0.2f) +(transform.up * 0.01f), Vector3.down)
        };

        foreach (var ray in rays) 
        {
            if(Physics.Raycast(ray, 0.1f, groundLayerMask))
                return true;
        }

        return false;
    }
}
