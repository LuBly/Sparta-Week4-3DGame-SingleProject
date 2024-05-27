using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerMovementController moveController;
    private PlayerLookController lookController;

    private void Awake()
    {
        CharacterManager.Instance.Player = this;
        moveController = GetComponent<PlayerMovementController>();
        lookController = GetComponent<PlayerLookController>();
    }
}
