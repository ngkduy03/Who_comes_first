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
            // if(Vector3.Distance(
            //                 players[i].token.transform.position,
            //                 standingPoint.GetChildTransform(standingPoint.ChildCount() - 1).position
            //             ) < 0.01f)
            // {
            //     Debug.Log(i);
            //     continue;   //! nhớ quay lại để làm token tới nơi ko cần toss dice!!!
            // }
                
            if (i != count)
            {
                players[i].token.GetComponent<PlayerMovement>().enabled = false;
            }
            else
            {
                players[i].token.GetComponent<PlayerMovement>().enabled = true;
                if(DIce.canCount)
                {

                    // if (Vector3.Distance(
                    //         players[i].token.transform.position,
                    //         standingPoint.GetChildTransform(standingPoint.ChildCount() - 1).position
                    //     ) < 0.01f
                    // )
                    //     return;
                    players[i].turns++;
                    DIce.canCount = false;
                }
            }
        }
    }
    public PlayerMovement GetCurrentToken()
    {
        return players[count].token.GetComponent<PlayerMovement>();
    }
}
