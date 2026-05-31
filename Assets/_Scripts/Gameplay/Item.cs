using System;
using UnityEngine;

public class Item : MonoBehaviour
{

    public bool Dangerous;
    public bool Interactable;
    public int EffectNum;
    public bool Purchasable;
    public int Price;
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

    public void ApplyEffect()
    {
        GameManager.Instance.ApplyEffect(this);
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

        if (Purchasable)
        {
            if (GameManager.Instance.GetPlayer().HowMuchMoneys() < Price)
            {
                Debug.Log("Player doesnt have enough moneys :(");
                return;
            }
            else
            {
                GameManager.Instance.GetPlayer().PurchaseItem(this);
                Destroy(gameObject);
            }

        }

        GameManager.Instance.ApplyEffect(this);

        Debug.Log("Item clicked");


        // change game state if it was bounty
        if (luggageParent.isBounty)
            GameManager.Instance.ChangeState(GameState.StartRound);

        Destroy(gameObject);
    }

}
