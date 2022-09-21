using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingManager : MonoBehaviour
{
    public static EndingManager Instance;

    private static int totalNPCKilled = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject, 2f);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    public void NPCKilled()
    {
        totalNPCKilled++;
    }

    public void ResolveEnding()
    {

    }

    private void BadEnding()
    {

    }

    private void GoodEnding()
    {

    }


}
