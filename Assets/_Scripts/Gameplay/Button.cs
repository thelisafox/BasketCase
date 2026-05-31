using UnityEngine;

public class Button : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        if (GameManager.Instance.State == GameState.EndRound)
        {
            GameManager.Instance.ChangeState(GameState.StartRound);
        } else
        {
            GameManager.Instance.conveyerBelt.Pop();
        }
    }
}
