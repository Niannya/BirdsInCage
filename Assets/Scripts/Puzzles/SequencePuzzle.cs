using System.Collections.Generic;
using UnityEngine;

public class SequencePuzzle : MonoBehaviour
{
    [SerializeField] private int[] correctSequence;
    private List<int> currentSequence = new List<int>();
    private bool isSolved;

    public void Submit(int id)
    {
        if (isSolved) return;

        if (currentSequence.Contains(id)) return;
        currentSequence.Add(id);
        Debug.Log($"Current sequence: [{string.Join(", ", currentSequence)}]");

        if (currentSequence.Count < correctSequence.Length) return;

        for (int i = 0; i < correctSequence.Length; i++)
        {
            if (currentSequence[i] != correctSequence[i])
            {
                currentSequence.Clear();
                return;
            }
        }
        isSolved = true;
        Debug.Log("Solved!");
    }
}

