using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
	// Carrega a cena de id 1
    public void PlayGame()
    {
        Debug.Log("Load game");
        //SceneManager.LoadScene(1);
    }

    public void SettingsMenu()
    {
        Debug.Log("Load Settings");
        //SceneManager.LoadScene("MenuConfig");
    }
	
    public void Main()
    {
        Debug.Log("Load Menu");
        //SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Saiu");
        Application.Quit();
    }
}
