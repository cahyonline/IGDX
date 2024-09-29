using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class IWantToGoPee : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject showThis;
    //public Image showThis;
    public FPSController playerController;
    // Start is called before the first frame update
    void Start()
    {
        showThis.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused == false)
            {
                Pausin();
            }

            else if(isPaused==true)
            {
                Unpausin();
            }
        }
    }

    public void Pausin()
    {
        Time.timeScale = 0f;
        isPaused = true;
        playerController.enabled = false;
        Debug.Log("Pause");
        showThis.SetActive(true);
    }
    public void Unpausin()
    {
        Time.timeScale = 1f;
        isPaused = false;
        playerController.enabled = true;
        Debug.Log("unPause");
        showThis.SetActive(false);
    }
}
