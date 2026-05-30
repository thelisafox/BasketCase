using System;
using UnityEngine;

public class Item : MonoBehaviour
{

    bool Dangerous;
    bool Interactable;
    public int EffectNum;
    int ID;
    Luggage luggageParent;
    public ItemsEffect effect;

    private void Initialize(Luggage luggage, int num, bool isBad, int stat, bool interactable, ItemsEffect NewEffect)
    {
        ID = num;
        bool Dangerous = isBad;
        EffectNum = stat;
        interactable = Interactable;
        luggageParent = luggage;
        effect = NewEffect;
    }

    public bool isItemBad()
    {
        return Dangerous;
    }

    private void Interact()
    {
        if (!luggageParent.isActive())
        {
            Debug.Log("Luggage is not active");
            return;
        }
        if (!Interactable)
        {
            {
                Debug.Log("Luggage is not interactable");
                return;
            }
        }
        GameManager.Instance.ApplyEffect(this);

        Debug.Log("Item clicked");
    }

}
