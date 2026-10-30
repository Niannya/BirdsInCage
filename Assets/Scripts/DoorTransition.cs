using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTransition : MonoBehaviour
{
    [SerializeField] private string targetSceneName;
    [SerializeField] private string targetSpawnPointName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        SceneTransitionData.TargetSpawnPointName = targetSpawnPointName;
        SceneManager.LoadScene(targetSceneName);
    }
}
