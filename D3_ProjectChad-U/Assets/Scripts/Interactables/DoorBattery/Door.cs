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
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y + 90f, transform.rotation.z);
    }

    private void CloseDoor()
    {
        Debug.Log("Fechei " + gameObject.name);
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y - 90f, transform.rotation.z);
    }

    

}
