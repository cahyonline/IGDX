using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGameKeyBlockerMenu : MonoBehaviour
{
    public GameObject enable1 , enable2 , enable3;
    public float howLong = 2f;
    private bool objectSwitch1 = true;
    private bool objectSwitch2 = true;
    // Start is called before the first frame update
    public void Start()
    {
        enable1.SetActive(false);
        objectSwitch1 = false;
        enable2.SetActive(false);
        objectSwitch2 = false;
        //enable3.SetActive(false);
        Debug.Log("MENU IS STARTING");
        StartEnable();
    }
    
    public void Update()
    {
        if(objectSwitch1 == false && objectSwitch2 == false)
        {
            enable1.SetActive(true);
            objectSwitch1 = true;
            enable2.SetActive(true);
            objectSwitch2 = true;
            Debug.Log("FORCED ACTIVE");
        }
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void StartEnable()
    {
        Delay();
    }

    void Rutine()
    {
        enable1.SetActive(true);
        enable2.SetActive(true);
        //enable3.SetActive(true);
        Debug.Log("MENU IS READY");
    }

    //public static void refresher() // FOR BUTTON  // ACCES THE STARTGAMEKEYBLOCKER SCRIPT
    //{
        //StartGameKeyBlocker startGame = FindObjectOfType<StartGameKeyBlocker>();
        //if(startGame !=null)
        //{
            //startGame.Start();
            //Debug.Log("Refreshed the Game From menu");
        //}
        //else
        //{
            //Debug.Log("AINT WORKING BOSS");    
        //}
    //} 
    void Delay()
    {
        StartCoroutine(DelayTime());
    }

    private IEnumerator DelayTime()
    {
        yield return new WaitForSeconds(howLong);
        Rutine();
    }
}   
