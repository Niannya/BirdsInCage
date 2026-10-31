using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTransition : MonoBehaviour
{
    [SerializeField] private string targetSceneName;
    [SerializeField] private string targetSpawnPointName;
    [SerializeField] private bool isLocked;
    [SerializeField] private float openDelay;
    [SerializeField] private string doorId;
    [SerializeField, TextArea] private string lockedMessage;

    private bool isTransitioning;

    [SerializeField] private SequencePuzzle keySource;
    private SpriteRenderer doorRenderer;
    private Collider2D doorCollider;
    [SerializeField] private SceneFader sceneFader;
    [SerializeField] private InteractionUI interactionUI;

    private void Awake()
    {
        doorRenderer = GetComponent<SpriteRenderer>();
        doorCollider = GetComponent<Collider2D>();
        if (GameProgress.IsDoorUnlocked(doorId))
        {
            isLocked = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject other = collision.gameObject;
        if (!other.CompareTag("Player") || isTransitioning) return;
        PlayerController controller = other.GetComponent<PlayerController>();
        

        if (isLocked)
        {
            if (keySource.TryUseKey())
            {
                isLocked = false;
                GameProgress.UnlockDoor(doorId);
            }
            else
            {
                interactionUI.Show(lockedMessage);
                controller.SetCanMove(false);
                return;
            }
        }

        isTransitioning = true;
        controller.SetCanMove(false);

        StartCoroutine(Transition());
    }

    private IEnumerator Transition()
    {
        doorRenderer.enabled = false;
        doorCollider.enabled = false;
        yield return new WaitForSeconds(openDelay);
        yield return StartCoroutine(sceneFader.FadeOut());
        SceneTransitionData.TargetSpawnPointName = targetSpawnPointName;
        SceneManager.LoadScene(targetSceneName);
    }
}
