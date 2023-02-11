using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] StandingPoint standingPoint;
    [SerializeField] Player player;
    [SerializeField] UIController uIController;

    [SerializeField] GameController gameController;
    private int currentPos = 0;
    public int nextPos = 0;
    private Vector3 dir;
    public bool isFinish = false;
    public static int gameOverCheck = -1;

    private void Awake()
    {
        gameOverCheck = -1;
    }
    private void FixedUpdate()
    {
        WinCheck();
        HandleMovement();
    }

    void HandleMovement()
    {
        if (currentPos <= nextPos)
        {
            dir = (standingPoint.GetChildTransform(currentPos).position - transform.position).normalized;
            if (Vector3.Distance(standingPoint.GetChildTransform(currentPos).position, transform.position) > 0.001f)
            {
                transform.position += dir * 0.1f * Time.deltaTime;
                // transform.position = standingPoint.GetChildTransform(currentPos).position;
            }
            else
            {
                currentPos++;
            }
            DIce.canToss = false;
        }
        else
        {
            if (nextPos != 0)
            {
                DIce.canToss = true;
            }
        }
    }
    public bool AreUThere()
    {
        return Vector3.Distance(transform.position, standingPoint.GetChildTransform(nextPos).position) < 0.1f;
    }
    void WinCheck()
    {
        if (isFinish)
            return;
        if (Vector3.Distance(
            transform.position, standingPoint.
            GetChildTransform(standingPoint.ChildCount() - 1).position)
            < 0.01f)
        {
            gameOverCheck++;
            uIController.GetPlayerScoreBoardName(player.playerName, gameOverCheck);
            uIController.GetPlayerScoreBoardTurn(player.turns, gameOverCheck);
            isFinish = true;
        }
    }
}
