
using System.Collections.Generic;
using UnityEngine;

public class DiceValue : MonoBehaviour
{
    Vector3 diceVelocity;
    public static int diceValue = 0;
    int a;
    void Awake()
    {
        diceValue = 0;
    }
    void FixedUpdate()
    {
        diceVelocity = DIce.diceVelocity;
    }
    private void OnTriggerStay(Collider other)
    {

        switch (other.gameObject.name)
        {
            case "SIde1":
                diceValue = 1;
                break;

            case "SIde2":
                diceValue = 2;
                break;

            case "SIde3":
                diceValue = 3;
                break;

            case "SIde4":
                diceValue = 4;
                break;

            case "SIde5":
                diceValue = 5;
                break;

            case "SIde6":
                diceValue = 6;
                break;
        }
    }
}
