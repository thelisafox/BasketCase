using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEditor.Progress;

public class GameManager : StaticInstance<GameManager>
{
    public static event Action<GameState> OnBeforeStateChanged;
    public static event Action<GameState> OnAfterStateChanged;
    [SerializeField] float TimeForOneRound;
    [SerializeField] public ConveyorBelt conveyerBelt;
    [SerializeField] public Player player;
    [SerializeField] public GameObject ScoreCanvas;
    [SerializeField] public GameObject InGameCanvas;
    [SerializeField] public Timer timer;

    public GameState State { get; private set; }
    
    private int RoundsPassed = 0;

    void Start() => ChangeState(GameState.Starting);

    public void ChangeState(GameState newState)
    {
        OnBeforeStateChanged?.Invoke(newState);

        State = newState;
        switch (newState)
        {
            case GameState.Starting:
                HandleStarting();
                break;
            case GameState.StartRound:
                HandleStartRound();
                break;
            case GameState.SpawningCases:
                HandleSpawningCases();
                break;
            case GameState.PlayerTurn:
                HandlePlayerTurn();
                break;
            case GameState.EndRound:
                HandleEndRound();
                break;
            case GameState.Win:
                break;
            case GameState.Lose:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnAfterStateChanged?.Invoke(newState);

        //Debug.Log($"New state: {newState}");
    }

    private void HandleStarting()
    {
        // Do some start setup, could be environment, cinematics etc

        // Eventually call ChangeState again with your next state
        Debug.Log("Starting game...");
        ChangeState(GameState.StartRound);
    }
    private void HandleStartRound()
    {
        RoundsPassed++;
        if (timer != null)
        {
            timer.startTimer(TimeForOneRound);
        }
        conveyerBelt.Pop();
        Debug.Log("Round started");
        InGameCanvas.SetActive(true);
        Transform DayText = InGameCanvas.transform.Find("DayText");
        DayText.gameObject.GetComponent<TextMeshProUGUI>().text = string.Format("Day {0}", RoundsPassed);
        ScoreCanvas.SetActive(false);
    }

    private void HandleSpawningCases()
    {

    }

    private void HandlePlayerTurn()
    {
        // If you're making a turn based game, this could show the turn menu, highlight available units etc

        // Keep track of how many units need to make a move, once they've all finished, change the state. This could
        // be monitored in the unit manager or the units themselves.
    }

    private void HandlePlayerTurnEnd()
    {
        // if (bBadLLuggage) Player.ApplyEffect(enum Item, int ItemStat)
        // Score calculation
    }
    private void HandleEndRound()
    {
        InGameCanvas.SetActive(false);

        ScoreCanvas.SetActive(true);
        Transform ScoreText = ScoreCanvas.transform.Find("Score Numbers");
        ScoreText.gameObject.GetComponent<TextMeshProUGUI>().text = player.HowMuchScore().ToString("00000");

        int quota = 1;
        if (RoundsPassed == 1)
        {
            quota = 100;
        }
        else if (RoundsPassed == 2)
        {
            quota = 200;
        }
        else if (RoundsPassed == 3)
        {
            quota = 300;
        }
        else if (RoundsPassed == 4)
        {
            quota = 400;
        }
        Transform QuotaText = ScoreCanvas.transform.Find("Quota Numbers");
        QuotaText.gameObject.GetComponent<TextMeshProUGUI>().text = quota.ToString("00000");

        Transform RespectPText = ScoreCanvas.transform.Find("Respect Points Number");
        RespectPText.gameObject.GetComponent<TextMeshProUGUI>().text = (player.HowMuchScore() - quota).ToString("00000");

        if (quota > player.HowMuchScore())
        {
            Transform LoseUI = ScoreCanvas.transform.Find("WL_Loosing");
            LoseUI.gameObject.SetActive(true);

            Transform WinUI = ScoreCanvas.transform.Find("WL_Winning");
            WinUI.gameObject.SetActive(false);

            Transform nextButton = ScoreCanvas.transform.Find("Button (NEXTSHFT)");
            nextButton.gameObject.SetActive(false);

        }
        if (RoundsPassed == 1 || RoundsPassed == 4 || RoundsPassed == 7)
        {

        }
    }

    public Player GetPlayer()
    {
        if (player != null)
        {
            return player;
        }
        return null;
    }
    public void RegisterTimer(Timer timerRef)
    {
        timer = timerRef;
    }
    public void ApplyEffect(Item item)
    {
        if (player != null){
            player.ApplyEffect(item);
        } else { Debug.Log("No player found"); }
    }
}

/// <summary>
/// This is obviously an example and I have no idea what kind of game you're making.
/// You can use a similar manager for controlling your menu states or dynamic-cinematics, etc
/// </summary>
[Serializable]
public enum GameState
{
    Starting = 0,
    StartRound = 1,
    SpawningCases = 2,
    PlayerTurn = 3,
    EndRound = 4,
    Win = 5,
    Lose = 6,
}
