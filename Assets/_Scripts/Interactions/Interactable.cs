using Unity.VisualScripting;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private void OnMouseUpAsButton()
    {
        // call function needed according to object pressed
        if (gameObject.name == "Button") gameObject.SendMessage("Interact");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                GameObject origin = null;
                // if the interactable has itself the collider
                if (hit.transform.gameObject == gameObject)
                {
                    origin = hit.transform.gameObject;
                    //hit.transform.SendMessage("Interact");
                }
                // if the child of the interactable has the collider
                else if (hit.transform.parent.gameObject == gameObject)
                {
                    origin = hit.transform.parent.gameObject;
                    //hit.transform.parent.SendMessage("Interact");
                }

                if (hit.transform.name != "Button" && origin != null)
                {
                    origin.SendMessage("Interact");
                }
            }
        }
    }
}
