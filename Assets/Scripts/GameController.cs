using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    List<Player> players = new List<Player>();
    [SerializeField] GameObject pList;
    [SerializeField] PlayerMovement playerMovement;
    int count = 0;
    void Start()
    {
        foreach (Transform tr in pList.GetComponentInChildren<Transform>())
        {
            players.Add(tr.GetComponent<Player>());
        }
        SetPlayerPiority();

        // foreach(Player player in players)
        // {
        //     Debug.Log(player);
        // }   

    }
    void Update()
    {
        if (PlayerMovement.areUThere)
        {
            PlayerTurn();
        }
    }
    void SetPlayerPiority()
    {
        foreach (Player player in players)
        {
            player.piority = Random.Range(0, 9);
        }
        players.Sort((a, b) => a.piority.CompareTo(b.piority));
        Debug.Log(players);
    }
    void PlayerTurn()
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
            }
        }
        count++;
        PlayerMovement.areUThere = false;
    }
}
