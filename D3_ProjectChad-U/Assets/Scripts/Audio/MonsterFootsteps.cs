using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFootsteps : MonoBehaviour
{
    private AudioManager audioManager;
    
    private Transform playerTransform;
    void Start()
    {      
        audioManager = AudioManager.instance;
        audioManager.PlaySound("Monster");
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        var distance = Vector3.Distance(transform.position, playerTransform.position);
        if(distance > 60f)
        {
            audioManager.ChangeSoundVolume("Monster", 0f);
        }
        else if (distance > 50f)
        {
            audioManager.ChangeSoundVolume("Monster", 0.1f);
        } else if (distance > 25f)
        {
            audioManager.ChangeSoundVolume("Monster", 0.22f);
        } else
        {
            audioManager.ChangeSoundVolume("Monster", 0.4f);
        }

    }


}
