using UnityEngine;

public class SequenceInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private int id;
    [SerializeField] private SequencePuzzle puzzle;
    [SerializeField, TextArea] private string message;

    public void Interact(InteractionUI interactionUI)
    {
        string resultMessage = puzzle.Submit(id);
        if (string.IsNullOrEmpty(resultMessage))
        {
            interactionUI.Show(message);
        }
        else
        {
            interactionUI.Show(resultMessage);
        }
    }
}
