using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : InteractableBase
{

    private void Awake()
    {
       
    }
    protected override void Interact()
    {
        Debug.Log("Is Working :) ");
    }
}
