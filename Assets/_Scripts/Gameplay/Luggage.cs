using System;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Luggage : MonoBehaviour
{
    bool Active = false;

    public Item[] items;
    bool IsLuggageBad()
    {
        bool bBad = false;
        foreach (Item item in items)
        {
            if (item.isItemBad())
            {
                bBad = true;

            }
        }
        return bBad;
    }

    private void Initialize()
    {
        SpawnItems();
    }

    private void setActive(bool active)
    {
        bool Active = active;
    }

    public bool isActive()
    {
        return Active;
    }

    //private void Awake() => GameManager.OnBeforeStateChanged += OnStateChanged;

    //private void OnDestroy() => GameManager.OnBeforeStateChanged -= OnStateChanged;

    private void SpawnItems()
    {
        
    }

    private void RemoveItem(Item item)
    {

    }

}
