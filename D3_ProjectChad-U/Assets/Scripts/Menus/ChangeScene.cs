using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : InteractableBase
{
    [SerializeField]
    private string sceneName;
    protected override void Interact()
    {
        SceneManager.LoadScene(sceneName);
    }

}
