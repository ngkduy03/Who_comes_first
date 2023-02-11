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
        canToss = true;
        canCount = true;
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
        if (PlayerMovement.gameOverCheck == 3)
        {
            return;
        }
        if (canToss)
        {
            diceVelocity = myBody.velocity;
            if (Input.GetKeyDown(KeyCode.Space) && Mathf.Approximately(diceVelocity.sqrMagnitude, 0f))
            {
                if (gameController.GetCurrentToken().AreUThere() == false)
                    return;
                myBody.useGravity = true;
                float dirX = Random.Range(100, 300);
                float dirY = Random.Range(100, 300);
                float dirZ = Random.Range(100, 300);
                myBody.velocity = Vector3.up * 3f;
                myBody.AddTorque(dirX, dirY, dirZ);
                canToss = false;
                canCount = true;

            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<Collider>().CompareTag("plane"))
        {
            myBody.velocity = Vector3.zero;
            myBody.angularVelocity = Vector3.zero;
            Invoke(nameof(SetNextPosValue), 0.01f);
            canToss = true;
        }
    }

    public bool _Debug = false;
    void SetNextPosValue()
    {
        // if(PlayerMovement.gameOverCheck == 3)
        //     return;
        while (gameController.GetCurrentToken().isFinish)
        {
            gameController.count++;
        }
        gameController.PlayerTurn();
        gameController.GetCurrentToken().nextPos += DiceValue.diceValue;
        int nexPost = Mathf.Min(gameController.GetCurrentToken().nextPos, 20);
        if (_Debug)
        {
            nexPost = 20;
        }
        gameController.GetCurrentToken().nextPos = nexPost;
        gameController.count++;
    }
}

