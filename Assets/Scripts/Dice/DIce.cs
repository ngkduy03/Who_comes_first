using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DIce : MonoBehaviour
{
    static Rigidbody myBody;
    public static Vector3 diceVelocity;
    bool canToss = true;
    public static bool firstToss = true;
    private void Awake() {
//            diceVelocity = myBody.velocity;
    }
    void Start()
    {
        myBody = GetComponent<Rigidbody>();
        myBody.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        TossDice();
    }
    void TossDice()
    {
        if(canToss)
        {
            diceVelocity = myBody.velocity;
            if(Input.GetKeyDown(KeyCode.Space))
            {
                myBody.useGravity = true;
                float dirX = Random.Range(0,500);
                float dirY = Random.Range(0,500);
                float dirZ = Random.Range(0,500);
                myBody.AddForce(new Vector3(0,1,0)*130);
                myBody.AddTorque(dirX,dirY,dirZ);
                canToss = false;
                if(!firstToss)
                {
                }
                // firstToss = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other) {
        
        if(other.GetComponent<Collider>().CompareTag("plane")){
           Invoke(nameof(SetNextPosValue),0.01f); 
        }
    }
    void SetNextPosValue()
    {
            PlayerMovement.nextPos += DiceValue.diceValue;
            canToss = true;
            Debug.Log(PlayerMovement.nextPos.ToString() +" "+ DiceValue.diceValue.ToString());
    }
    // private void OnTriggerExit(Collider other) {
    //     DiceValue.diceValue=0;
        
    // }
}
