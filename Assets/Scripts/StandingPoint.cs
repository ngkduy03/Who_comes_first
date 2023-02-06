using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingPoint : MonoBehaviour
{
    public Transform GetChildTransform(int index)
    {
        return transform.GetChild(index);
    }   
    public int ChildCount()
    {
        return transform.childCount;
    } 
    
}
