using System;
using UnityEngine;

public class Item : MonoBehaviour
{

    public bool Dangerous;
    public bool Interactable;
    public int EffectNum;
    int ID;
    Luggage luggageParent;
    public ItemsEffect effect;

    public void Initialize(Luggage luggage)
    {
        luggageParent = luggage;
    }

    public bool isItemBad()
    {
        return Dangerous;
    }

    private void Interact()
    {
        if (luggageParent != null)
        {
            if (!luggageParent.isActive())
            {
                Debug.Log("Luggage is not active");
                return;
            }
        }

        if (!Interactable)
        {
            {
                Debug.Log("Item is not interactable");
                return;
            }
        }

        if (effect == ItemsEffect.ScoreInstant)
        {
            Player player = GameManager.Instance.GetPlayer();
            if (!player.canPlayerCollectMoney())
            {
                {
                    Debug.Log("Player cannot collect moneys :(");
                    return;
                }
            }
        }
        GameManager.Instance.ApplyEffect(this);

        Debug.Log("Item clicked");
        Destroy(gameObject);
    }

}
