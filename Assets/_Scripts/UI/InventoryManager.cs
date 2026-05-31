using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public const int MaxSlots = 4;

    public List<InventoryItem> items = new List<InventoryItem>();

    public delegate void InventoryChanged();
    public event InventoryChanged OnInventoryChanged;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public bool AddItem(InventoryItem item)
    {
        if (items.Count >= MaxSlots)
        {
            Debug.Log("Inventory Full");
            return false;
        }

        items.Add(item);

        OnInventoryChanged?.Invoke();

        Debug.Log(item.itemName + " added to inventory");

        return true;
    }

    public void UseItem(int slotIndex)
    {
        if (slotIndex < 0 || slotIndex >= items.Count)
            return;

        InventoryItem item = items[slotIndex];

        item.Use();

        items.RemoveAt(slotIndex);

        OnInventoryChanged?.Invoke();
    }
}