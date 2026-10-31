using System.Collections.Generic;

public static class GameProgress
{
    private static readonly HashSet<string> unlockedDoors
        = new HashSet<string>();
    private static readonly HashSet<string> completedPuzzles
        = new HashSet<string>();
    public static void UnlockDoor(string doorId)
    {
        unlockedDoors.Add(doorId);
    }

    public static bool IsDoorUnlocked(string doorId)
    {
        return unlockedDoors.Contains(doorId);
    }

    public static void CompletePuzzle(string puzzleId)
    {
        completedPuzzles.Add(puzzleId);
    }

    public static bool IsPuzzleCompleted(string puzzleId)
    {
        return completedPuzzles.Contains(puzzleId);
    }
}
