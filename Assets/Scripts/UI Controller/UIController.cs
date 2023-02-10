using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public List<TMP_InputField> inputNames = new List<TMP_InputField>();
    public List<GameObject> players = new List<GameObject>();
    public GameObject canvas;

    public void SetPlayerName()
    {
        int i = 0;
        foreach (var inputName in inputNames)
        {
            players[i].GetComponent<Player>().playerName = inputName.text;
            i++;
        }
        canvas.SetActive(false);
    }
}
