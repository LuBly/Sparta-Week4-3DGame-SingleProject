using UnityEngine;

public class JumpMushroom : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerMovementController playerMovementController))
        {
            playerMovementController.Jump(jumpForce);
        }
    }
}
