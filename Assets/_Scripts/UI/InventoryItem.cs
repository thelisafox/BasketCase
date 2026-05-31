using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public string itemName;

    private void OnMouseDown()
    {
        if (InventoryManager.Instance.AddItem(this))
        {
            gameObject.SetActive(false);
        }
    }

    public virtual void Use()
    {
        Debug.Log("Used item: " + itemName);
    }
}