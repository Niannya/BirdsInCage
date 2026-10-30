using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Transform interactionOrigin;
    [SerializeField] private float interactionDistance = 1.5f;
    [SerializeField] private LayerMask interactionLayers;

    private PlayerController playerController;
    [SerializeField] private InteractionUI interactionUI;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }
    private void Update()
    {
        Vector2 direction = playerController.FacingDirection;
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (interactionUI.IsVisible)
            {
                interactionUI.Hide();
                playerController.SetCanMove(true);
                return;
            }
            RaycastHit2D hit = Physics2D.Raycast(interactionOrigin.position, direction, interactionDistance, interactionLayers);
            if (hit.collider != null)
            {
                SimpleInteractable simpleInteractable = hit.collider.GetComponent<SimpleInteractable>();
                if (simpleInteractable != null)
                {
                    simpleInteractable.Interact(interactionUI);
                    playerController.SetCanMove(false);
                }
            }
        }
    }
}
