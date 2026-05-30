using System;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using static UnityEngine.Rendering.DebugUI;

public class Player : MonoBehaviour
{
    public void Awake()
    {
        GameManager.Instance.RegisterPlayer(this);
    }

    public void Update()
    {

    }

    public void ApplyEffect(Item item)
    {
        ItemsEffect effect = item.effect;
        switch (effect)
        {
            case ItemsEffect.TimeInstant:
                GameManager.Instance.timer.addTime(item.EffectNum);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(effect), effect, null);
        }
    }
}

[Serializable]
public enum ItemsEffect
{
    TimeInstant = 0,
    Score = 1,
    Invetory = 2,
    PlayerTurn = 3,
    EndRound = 4,
    Win = 5,
    Lose = 6,
}

