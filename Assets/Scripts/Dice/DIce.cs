using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DIce : MonoBehaviour
{
    static Rigidbody myBody;
    public static Vector3 diceVelocity;
    public static bool canToss = true;
    private StandingPoint standingPoint;
    [SerializeField] private GameController gameController;
    public static bool canCount = true;
    private void Awake()
    {

    }
    void Start()
    {
        standingPoint = GetComponent<StandingPoint>();
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
        if (canToss)
        {
            diceVelocity = myBody.velocity;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gameController.PlayerTurn();
                if (gameController.GetCurrentToken().AreUThere() == false)
                    return;

                myBody.useGravity = true;
                float dirX = Random.Range(0, 500);
                float dirY = Random.Range(0, 500);
                float dirZ = Random.Range(0, 500);
                myBody.AddForce(new Vector3(0, 1, 0) * 130);
                myBody.AddTorque(dirX, dirY, dirZ);
                // canToss = false;
                canCount = true;

            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<Collider>().CompareTag("plane"))
        {
            Invoke(nameof(SetNextPosValue), 0.01f);
        }
    }
    void SetNextPosValue()
    {
        gameController.GetCurrentToken().nextPos += DiceValue.diceValue;
        gameController.GetCurrentToken().nextPos = Mathf.Min(gameController.GetCurrentToken().nextPos, 20);
        gameController.count++;
    }
}

