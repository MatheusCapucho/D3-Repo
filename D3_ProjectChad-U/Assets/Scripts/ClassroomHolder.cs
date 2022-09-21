using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassroomHolder : MonoBehaviour
{
    [SerializeField]
    private bool[] hasNPC;

    private int current;
   
    public bool GetNPC(int id)
    {
        current = id;
        return hasNPC[id];
    }

    public void SetNPC()
    {
        hasNPC[current] = false;
    }


}
