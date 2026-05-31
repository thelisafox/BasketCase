using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using static UnityEngine.Rendering.DebugUI;

public class Player : MonoBehaviour
{
    private int Score = 0;
    private bool canCollectMoney = true;
    private int Moneys = 0;
    public void Start()
    {
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
        Transform ScoreText = GameManager.Instance.InGameCanvas.transform.Find("ScoreText");
        ScoreText.gameObject.GetComponent<TextMeshProUGUI>().text = Score.ToString("00000");

        Debug.Log($"CurrentScore: {Score}");
    }

    public bool canPlayerCollectMoney()
    {
        return canCollectMoney;
    }

    public void PurchaseItem(Item item)
    {
        Moneys = Moneys - item.Price;
        ApplyEffect(item);
    }

    public int HowMuchMoneys()
    {
        return Moneys;
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

