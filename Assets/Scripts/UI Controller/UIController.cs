using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class UIController : MonoBehaviour
{
    public List<TMP_InputField> inputNames = new List<TMP_InputField>();
    public List<GameObject> players = new List<GameObject>();
    public List<TMP_Text> playerNames = new List<TMP_Text>();
    public List<TMP_Text> playerTurns = new List<TMP_Text>();
    private static List<string> StaticNames = new List<string>();
    public GameObject enterNameCanvas;
    public GameObject scoreBoard;
    private bool endGameOnce = false;
    [SerializeField] GameObject dice;
    private void Start()
    {

        scoreBoard.SetActive(false);
        enterNameCanvas.SetActive(StaticNames.Count == 0);
        dice.SetActive(StaticNames.Count > 0);
        int i = 0;
        foreach (var inputName in StaticNames)
        {
            players[i].GetComponent<Player>().playerName = inputName;
            i++;
        }
    }
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
            StaticNames.Add(inputName.text);
            i++;
        }
        enterNameCanvas.SetActive(false);
        dice.SetActive(true);
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
        if (PlayerMovement.gameOverCheck == 3 )//&& !endGameOnce)
        {
            // endGameOnce = true;
            scoreBoard.SetActive(true);
        }
    }
    public void PlayAgain()
    {
        scoreBoard.SetActive(false);
        dice.SetActive(true);
        SceneManager.LoadScene("Bootloader", LoadSceneMode.Single);
    }

    public void NewGame()
    {
        StaticNames.Clear();
        PlayAgain();
    }
}