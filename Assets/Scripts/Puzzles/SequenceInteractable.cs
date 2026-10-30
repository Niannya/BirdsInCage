using System.Collections.Generic;
using UnityEngine;

public class SequenceInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private int id;
    [SerializeField] private SequencePuzzle puzzle;
    [SerializeField, TextArea] private string message;

    public void Interact(InteractionUI interactionUI)
    {
        puzzle.Submit(id);
        interactionUI.Show(message);
    }
}
