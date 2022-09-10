using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switches : MonoBehaviour
{
    [SerializeField] private Door controledDoor;
    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Battery"))
            controledDoor.ResolveDoor();

    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Battery"))
            controledDoor.ResolveDoor();

    }
}
