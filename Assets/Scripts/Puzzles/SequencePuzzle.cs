using System.Collections.Generic;
using UnityEngine;

public class SequencePuzzle : MonoBehaviour
{
    [SerializeField] private int[] correctSequence;
    private List<int> currentSequence = new List<int>();
    [SerializeField] private string puzzleId;
    [SerializeField, TextArea] private string solvedMessage;
    [SerializeField, TextArea] private string failedMessage;
    [SerializeField, TextArea] private string alreadySolvedMessage;

    private bool isSolved;
    private bool hasKey;

    private void Awake()
    {
        if (GameProgress.IsPuzzleCompleted(puzzleId)){
            isSolved = true;
            hasKey = false;
        }
    }

    public string Submit(int id)
    {
        if (isSolved) return alreadySolvedMessage;

        if (currentSequence.Contains(id)) return null;
        currentSequence.Add(id);

        if (currentSequence.Count < correctSequence.Length) return null;

        for (int i = 0; i < correctSequence.Length; i++)
        {
            if (currentSequence[i] != correctSequence[i])
            {
                currentSequence.Clear();
                return failedMessage;
            }
        }
        isSolved = true;
        hasKey = true;
        GameProgress.CompletePuzzle(puzzleId);
        return solvedMessage;
    }

    public bool TryUseKey()
    {
        if(!hasKey) return false;

        hasKey = false;
        return true;
    }
}

