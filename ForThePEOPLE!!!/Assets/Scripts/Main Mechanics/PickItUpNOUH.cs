using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickItUpNOUH : MonoBehaviour
{
    public GameObject InterIc ;
    private float popTime = 1f;
    private float SpamJamTime = 3f;
    private static int counterItem;
    public MeshRenderer meshRenderer;
    public GameObject Spamhandler;
    public AudioSource pickSound;
    private float DelaySeconds = 2f;
    // Start is called before the first frame update
    void Start()
    {
        DelayStart();
        InterIc.SetActive(false);
        //pickSound.enabled = false;
        
    }
    void OnTriggerStay(Collider other) //INSIDE SHOW INTERIC
    {
        if(other.CompareTag("TrigDoor"))
        //Debug.Log("inside");
        {
            InterIc.SetActive(true);
            if(Input.GetKey(KeyCode.E))
            {   
                //IncreaseScore();
                NoSpam();
                TimePopUp();
                meshRenderer.enabled = false;
                InterIc.SetActive(false);
                Debug.Log("ZONK !");
                pickSound.Play();
            }
        }  
    }
    void OnTriggerExit(Collider other) //OUTSIDE UNSHOW INTERIC
    {
        if(other.CompareTag("TrigDoor"))
        {
            InterIc.SetActive(false);
        }
    }

    public void TimePopUp() //SHOW POPUP IMAGE
    {
        StartCoroutine(Timed());
        //Debug.Log("TimePopUp");
    }
    private IEnumerator Timed()
    {
        //ItemIc.gameObject.SetActive(true);
        //PopIc.gameObject.SetActive(true);
        yield return new 
        WaitForSeconds(popTime);
        InterIc.SetActive(false);
        
        //gameObject.SetActive(false);
        //Debug.Log("Collet =" + counterItem);
    }

    public void NoSpam()
    {
        StartCoroutine(NoSpamTime());
    }
    private IEnumerator NoSpamTime()
    {
        Spamhandler.SetActive(false);
        Debug.Log("Spam delayed");
        yield return new WaitForSeconds(SpamJamTime);
        Spamhandler.SetActive(true);
        Debug.Log("Delay ended");
        //Debug.Log("Collet =" + counterItem);
        gameObject.SetActive(false);
    }

    void DelayStart()
    {
        StartCoroutine(TheDelay());
    }

    private IEnumerator TheDelay()
    {
        pickSound.enabled = false;
        yield return new WaitForSeconds(DelaySeconds);
        pickSound.enabled = true;

    }
}

