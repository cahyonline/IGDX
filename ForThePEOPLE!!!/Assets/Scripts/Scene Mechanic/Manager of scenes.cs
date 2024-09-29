using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Make sure this is included

public class ManagerofScenes : MonoBehaviour
{
    void Start()
    {
        creditz.SetActive(false);
    }
    public GameObject creditz;
    // Reloads the Main Menu scene
    public void ToMainmenu()
    {
        SceneManager.LoadScene("Main Menu");
        Debug.Log("RESTARTED to Main Menu");
        Time.timeScale = 1;
    }

    // Loads the Gameplay scene
    public void ToGame()
    {
        SceneManager.LoadScene("Gameplay");
        Debug.Log("RESTARTED to Gameplay");
        Time.timeScale = 1f;
    }

    public void ToDebug()
    {
        //SceneManager.LoadScene("Test");
        Debug.Log("Responsive");
    }

    public void ToWin()
    {
        SceneManager.LoadScene("Win");
        Time.timeScale = 1;
    }

    public void ToCredits()
    {
        creditz.SetActive(true);
        Debug.Log("Credits");
    }

    public void CloseCredit()
    {
        creditz.SetActive(false);
        Debug.Log("NO Credits");
    }

    public void ToCutScene()
    {
        SceneManager.LoadScene("Start Scene");
        Time.timeScale = 1;
    }

    public void ImmaHeadOut()
    {
        Debug.Log("ImmaFuckOutaHier");
        Application.Quit();
    }



}   

