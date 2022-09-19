using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{

    [SerializeField]
    private string soundName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            AudioManager.instance.PlaySound(soundName);
    }
}
