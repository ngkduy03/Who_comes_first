using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public List<TMP_InputField> inputNames = new List<TMP_InputField>();
    public List<GameObject> players = new List<GameObject>();
    public List<TMP_Text> playerNames = new List<TMP_Text>();
    public List<TMP_Text> playerTurns = new List<TMP_Text>();
    public GameObject enterNameCanvas;
    public GameObject scoreBoard;
    private void Update()
    {
        GameOver();
    }
    public void SetPlayerName()
    {
        int i = 0;
        foreach (var inputName in inputNames)
        {
            players[i].GetComponent<Player>().playerName = inputName.text;
            i++;
        }
        enterNameCanvas.SetActive(false);
    }
    public void GetPlayerScoreBoardName(string a, int i)
    {
        playerNames[i].text = a;
    }
    public void GetPlayerScoreBoardTurn(int a, int i)
    {
        playerTurns[i].text = a.ToString();
    }
    public void GameOver()
    {
        if (PlayerMovement.gameOverCheck == 3)
        {
            scoreBoard.SetActive(true);
        }
    }
}