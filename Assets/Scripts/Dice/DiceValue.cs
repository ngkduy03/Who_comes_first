
using System.Collections.Generic;
using UnityEngine;

public class DiceValue : MonoBehaviour
{
  Vector3 diceVelocity;
  public static int diceValue =0;
  int a;
  void FixedUpdate(){
    diceVelocity = DIce.diceVelocity;
} 
    private void OnTriggerStay(Collider other) {
        switch(other.gameObject.name)
        {
            case "SIde1":
                diceValue = 11;
                break;
            
            case "SIde2":
                diceValue = 12;
                break;

            case "SIde3":
                diceValue = 13;
                break;

            case "SIde4":
                diceValue = 14;
                break;

            case "SIde5":
                diceValue = 15;
                break;
            
            case "SIde6":
                diceValue = 16;
                break;
    }
  }
}
