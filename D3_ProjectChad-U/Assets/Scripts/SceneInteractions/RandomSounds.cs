using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSounds : MonoBehaviour
{
    string soundName;

    [SerializeField]
    private float timer = 3f;  
    private float current = 0f;

    [SerializeField]
    private string[] soundNames;

    private void OnEnable()
    {
        timer = Random.Range(30f, 120f);
    }

    private void Update()
    {
        current += Time.deltaTime;
        if (current > timer)
        {
            current = 0f;
            PlayRandomSound();
        }
    }

    private void PlayRandomSound()
    {
        int rng = Random.Range(1, soundNames.Length);
        float rngTimer = Random.Range(30f, 120f);

        soundName = soundNames[rng];

        timer = rngTimer;
        AudioManager.instance.PlaySound(soundName);

    }

}
