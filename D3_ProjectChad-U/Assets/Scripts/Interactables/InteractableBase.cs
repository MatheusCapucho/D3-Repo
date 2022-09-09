using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableBase : MonoBehaviour
{
    public void BaseInteract()
    {
        Interact(); 
    }

    protected virtual void Interact() { }

}
