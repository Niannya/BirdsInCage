using UnityEngine;

public class SimpleInteractable : MonoBehaviour, IInteractable
{
    [SerializeField]
    [TextArea]
    private string message = "test";
    public void Interact(InteractionUI interactionUI)
    {
        interactionUI.Show(message);
    }
}
