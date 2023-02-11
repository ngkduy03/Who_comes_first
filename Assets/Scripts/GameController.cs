using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    List<Player> players = new List<Player>();
    [SerializeField] GameObject pList;
    [SerializeField] StandingPoint standingPoint;
    public int count = 0;
    void Start()
    {
        // standingPoint = GetComponent<StandingPoint>();
        foreach (Transform tr in pList.GetComponentInChildren<Transform>())
        {
            players.Add(tr.GetComponent<Player>());
        }
        SetPlayerPiority();

    }
    void Update()
    {

    }
    void SetPlayerPiority()
    {
        foreach (Player player in players)
        {
            player.piority = Random.Range(0, 9);
        }
        players.Sort((a, b) => a.piority.CompareTo(b.piority));
    }
    public void PlayerTurn()
    {
        count %= players.Count;
        for (int i = 0; i < players.Count; i++)
        {
            if (i != count)
            {
                players[i].token.GetComponent<PlayerMovement>().enabled = false;
            }
            else
            {
                players[i].token.GetComponent<PlayerMovement>().enabled = true;
                
                // if(players[i].token.GetComponent<PlayerMovement>().isFinish == true)
                //     return;
                if (DIce.canCount)
                {
                    players[i].turns++;
                    DIce.canCount = false;
                }
            }
        }
    }
    public PlayerMovement GetCurrentToken()
    {
        Debug.Log(count);
        return players[count % players.Count].token.GetComponent<PlayerMovement>();
    }
}
