using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SurvivalTime : MonoBehaviour
{
    [SerializeField]
    private float survivalTimer = 75f;
    private float timer;

    [SerializeField]
    private TextMeshProUGUI textTimerComponent;

    private GameObject monster;

    void Start()
    {
        timer = survivalTimer;
        monster = GameObject.FindGameObjectWithTag("Enemy");
    }
    private void OnEnable()
    {
        textTimerComponent.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        if (monster != null)
            monster.SetActive(false);
            
    }

    private void FixedUpdate()
    {
        if (timer > 0f)
        {
            timer -= Time.fixedDeltaTime;
            UpdateUI();
           
            if (IsTimerComplete())
            {
                textTimerComponent.gameObject.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }

    private bool IsTimerComplete()
    {
        return (timer <= 0f);
    }

    private void UpdateUI()
    {
        string str;
        int min, sec;
        sec = (int)timer;
        min = 0;
        if (timer >= 60f)
        {
            min = (int)timer / 60;
            sec = (int)timer % 60;
        }
        if (sec < 10)
            str = "" + min + ":0" + sec;
        else
            str = "" + min + ":" + sec;

        textTimerComponent.text = str;
    }

}
