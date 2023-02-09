using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] StandingPoint standingPoint;
    private int currentPos = 0;
    public int nextPos = 0;
    private Vector3 dir;

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
       HandleMovement(); 
    }
    
    void HandleMovement()
    {
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
            DIce.canToss = false;
        }
        else
        {
            DIce.canToss = true;
        }
    }
    public bool AreUThere()
    {
        return Vector3.Distance(transform.position, standingPoint.GetChildTransform(nextPos).position) < 0.1f;
    }
    
}
