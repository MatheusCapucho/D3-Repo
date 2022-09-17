using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassroomHolder : MonoBehaviour
{
    [SerializeField]
    private bool[] hasNPC;
   
    public bool GetNPC(int id)
    {
        return hasNPC[id];
    }

}
