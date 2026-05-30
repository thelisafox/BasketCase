using UnityEngine;

public class Interactable : MonoBehaviour
{
    private void OnMouseUpAsButton()
    {
        // call function needed according to object pressed
        Destroy(gameObject);
    }
}
