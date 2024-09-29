using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StartGameKeyBlocker : MonoBehaviour
{
    public GameObject enable1 , enable2 , enable3;
    public PickItUp pickItUp;
    public PickItUpKeys pickItUpKeys;
    public float howLong = 3f;
    private bool objectStatus1 = true;
    // Start is called before the first frame update
    public void Start()
    {
        enable1.SetActive(false);
        objectStatus1 = false;
        //enable2.SetActive(false);
        //enable3.SetActive(false);
        pickItUp.enabled = false;
        pickItUpKeys.enabled = false;
        Debug.Log("GAME IS STARTING");
        StartEnable();
    }

    void Update()
    {
        if(objectStatus1 == false)
        {
            enable1.SetActive(true);
            objectStatus1 = true;
        }
    }

    // Update is called once per frame
    void StartEnable()
    {
        Delay();
    }

    //private void Awake()
    //{
        //DontDestroyOnLoad(gameObject);
    //}

    void Rutine()
    {
        //enable1.SetActive(true);
        //enable2.SetActive(true);
        //enable3.SetActive(true);
        pickItUp.enabled = true;
        pickItUpKeys.enabled = true;
        Debug.Log("GAME IS READY");
    }

    //public static void refresher() // FOR BUTTON  // ACCES THE STARTGAMEKEYBLOCKER SCRIPT
    //{
        //StartGameKeyBlockerMenu startMenu = FindObjectOfType<StartGameKeyBlockerMenu>();
        //if(startMenu !=null)
        //{
            //startMenu.Start();
            //Debug.Log("Refreshed Menu From Game");
        //}
        //else
        //{
            //Debug.Log("AINT WORKING BOS");
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
