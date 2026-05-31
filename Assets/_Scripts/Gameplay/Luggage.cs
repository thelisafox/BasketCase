using System;
using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Luggage : MonoBehaviour
{
    bool Active = false;
    public int spawnrate;
    [SerializeField] public int minProbabilityRange;
    [SerializeField] public int maxProbabilityRange;

    public Item[] items;

    private void Start()
    {
        Initialize();
    }

    public void IsLuggageBad()
    {
        foreach (Item item in items)
        {
            if (item.isItemBad())
            {
                item.ApplyEffect();

            }
        }

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
