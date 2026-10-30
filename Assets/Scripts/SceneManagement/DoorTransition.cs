using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTransition : MonoBehaviour
{
    [SerializeField] private string targetSceneName;
    [SerializeField] private string targetSpawnPointName;
    [SerializeField] private bool isLocked;
    [SerializeField] private float openDelay;
    [SerializeField] private SequencePuzzle keySource;
    [SerializeField] private GameObject doorBlocker;
    [SerializeField] private SceneFader sceneFader;
    private bool isTransitioning;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player") || isTransitioning) return;

        if (isLocked)
        {
            if (keySource.TryUseKey())
            {
                isLocked = false;
            }
            else
            {
                return;
            }
        }

        isTransitioning = true;
        PlayerController controller = other.GetComponent<PlayerController>();
        controller.SetCanMove(false);

        StartCoroutine(Transition());
    }

    private IEnumerator Transition()
    {
        doorBlocker.SetActive(false);
        yield return new WaitForSeconds(openDelay);
        yield return StartCoroutine(sceneFader.FadeOut());
        SceneTransitionData.TargetSpawnPointName = targetSpawnPointName;
        SceneManager.LoadScene(targetSceneName);
    }
}
