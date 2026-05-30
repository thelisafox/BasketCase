using System;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Luggage : MonoBehaviour
{
    bool Active = false;
    public int spawnrate;

    public Item[] items;

    private void Start()
    {
        Initialize();
    }

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
        foreach (Item item in items)
        {
            item.Initialize(this);
        }
    }

    public void setActive(bool active)
    {
        Active = active;
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
