using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] StandingPoint standingPoint;
    private int currentPos = 0;
    private int nextPos = 0;
    private Vector3 dir;
    
    // Update is called once per frame
    void Update()
    {
        RollDice();
    }
    private void FixedUpdate()
    {

       HandleMovement(); 
        
    }
    
    void HandleMovement()
    {
        if(nextPos > standingPoint.ChildCount())
            return;
        
        if(currentPos <= nextPos)
        {
            dir = (standingPoint.GetChildTransform(currentPos).position-transform.position).normalized;
            if(Vector3.Distance(standingPoint.GetChildTransform(currentPos).position,transform.position)>0.001f)
            {
                transform.position += dir*0.1f*Time.deltaTime;
            }
            else{
                currentPos++;
            }

        }
    }
    int RollDice()
    {
        if(Input.GetKeyDown("space"))
        {
            nextPos += Random.Range(1,6);
            // currentPos++;
        }
        return nextPos;
    }
}
