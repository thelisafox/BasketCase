using System;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using static UnityEngine.Rendering.DebugUI;

public class Player : MonoBehaviour
{
    private int Score = 0;
    private bool canCollectMoney = false;
    public void Start()
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
            case ItemsEffect.ScoreInstant:
                if (canCollectMoney) addScore(item.EffectNum);
                break;
            case ItemsEffect.UnlockModuleScore:
                canCollectMoney = true;
                Debug.Log("Player can now collect moneys");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(effect), effect, null);
        }
    }

    public void addScore(int addedScore)
    {
        Score += addedScore;
        if (Score < 0)
        {
            GameManager.Instance.ChangeState(GameState.EndRound);
        }

        Debug.Log($"CurrentScore: {Score}");
    }

    public bool canPlayerCollectMoney()
    {
        return canCollectMoney;
    }

}

[Serializable]
public enum ItemsEffect
{
    TimeInstant = 0,
    ScoreInstant = 1,
    UnlockModuleScore = 2,
    PlayerTurn = 3,
    EndRound = 4,
    Win = 5,
    Lose = 6,
}

