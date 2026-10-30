using UnityEngine;

public class SimpleInteractable : MonoBehaviour
{
    [SerializeField]
    [TextArea]
    private string message = "test";
    public void Interact()
    {
        Debug.Log(message);
    }
}
