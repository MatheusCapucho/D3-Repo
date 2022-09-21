using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool doorIsOpen = true;

    private GameObject openedDoor;
    private GameObject closedDoor;

    void Start()
    {
        openedDoor = transform.GetChild(0).gameObject;
        closedDoor = transform.GetChild(1).gameObject;
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
        closedDoor.SetActive(false);
        openedDoor.SetActive(true);
    }

    private void CloseDoor()
    {
        Debug.Log("Fechei " + gameObject.name);
        closedDoor.SetActive(true);
        openedDoor.SetActive(false);
    }

    

}
