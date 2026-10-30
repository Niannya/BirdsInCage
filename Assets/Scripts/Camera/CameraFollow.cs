using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector2 nextPos;
    private float halfHeight;
    private float halfWidth;

    [SerializeField] private Transform target;

    [SerializeField] private Transform up;
    [SerializeField] private Transform down;
    [SerializeField] private Transform left;
    [SerializeField] private Transform right;

    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = GetComponent<Camera>();
        halfHeight = mainCamera.orthographicSize;
        halfWidth = mainCamera.orthographicSize * mainCamera.aspect;
    }

    private void LateUpdate()
    {
        nextPos.x = Mathf.Clamp(target.position.x, left.position.x + halfWidth, right.position.x - halfWidth);
        nextPos.y = Mathf.Clamp(target.position.y, down.position.y + halfHeight, up.position.y - halfHeight);
        transform.position = new Vector3(nextPos.x, nextPos.y, -10);
    }
}
