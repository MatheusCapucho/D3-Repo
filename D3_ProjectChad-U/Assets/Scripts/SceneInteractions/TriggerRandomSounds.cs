using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRandomSounds : MonoBehaviour
{
    private RandomSounds randomSounds;
    private void Awake()
    {
        randomSounds = GetComponent<RandomSounds>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            randomSounds.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            randomSounds.enabled = false;
        }
    }
}
