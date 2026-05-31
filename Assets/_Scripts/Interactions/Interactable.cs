using Unity.VisualScripting;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private int kaka = 0;

    /*private void OnMouseUpAsButton()
    {
        // call function needed according to object pressed
        gameObject.SendMessage("Interact");
    }*/

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && kaka == 0)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name != "Button" && hit.transform.parent.GetComponent<Item>() != null)
                {
                    kaka = 1;
                    hit.transform.parent.SendMessage("Interact");
                    print(hit.transform.parent.name);
                    print(hit.transform.name);
                }
            }
        }
    }
}
