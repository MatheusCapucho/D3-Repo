using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool doorIsOpen = true;
    void Start()
    {
        
    }

    public void ResolveDoor()
    {
        if (doorIsOpen)
            CloseDoor();
        else
            OpenDoor();
        doorIsOpen = !doorIsOpen;

    }

    private void OpenDoor()
    {
        Debug.Log("Abri " + gameObject.name);
        transform.position += new Vector3(0, 3, 0);
    }

    private void CloseDoor()
    {
        Debug.Log("Fechei " + gameObject.name);
        transform.position += new Vector3(0, -3, 0);
    }

    

}
