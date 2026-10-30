using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float interactionDistance = 1.5f;
    [SerializeField] private LayerMask interactionLayers;

    private PlayerController pc;

    private void Awake()
    {
        pc = GetComponent<PlayerController>();
    }
    private void Update()
    {
        Vector2 direction = pc.FacingDirection;
        if (Input.GetKeyDown(KeyCode.Z))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, interactionDistance, interactionLayers);
            if (hit.collider != null)
            {
                SimpleInteractable si = hit.collider.GetComponent<SimpleInteractable>();
                if (si != null)
                {
                    si.Interact();
                }
            }
        }
    }
}
