using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FlashingLight : MonoBehaviour
{
    [SerializeField]
    private float timer = 3f;
    private float timerOff = 0.5f;
    private float current = 0f;
    private float currentOff = 0f;

    private Light _light;

    private void Start()
    {
        _light = GetComponent<Light>();
        current = Random.Range(0f, timer);
    }
    private void Update()
    {
        current += Time.deltaTime;
        if (current > timer)
        {
            currentOff += Time.deltaTime;
            _light.enabled = false;
            if(currentOff > timerOff)
            {
                _light.enabled = true;
                current = 0f;
                currentOff = 0f;
            }
        }
    }
}
