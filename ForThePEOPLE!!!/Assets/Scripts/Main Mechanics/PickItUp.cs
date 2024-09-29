using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickItUp : MonoBehaviour
{
    public GameObject ItemIc , InterIc , PopIc;
    private float popTime = 2.2f;
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
        ItemIc.SetActive(false);
        InterIc.SetActive(false);
        PopIc.SetActive(false);
        counterItem = 0;
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
                IncreaseScore();
                NoSpam();
                TimePopUp();
                meshRenderer.enabled = false;
                InterIc.SetActive(false);
                Debug.Log("Collet =" + counterItem);
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

    public void IncreaseScore()
    {
        counterItem = counterItem +1; // Increment the score
    }

    public void Refresher()
    {
        counterItem = 0;
        Debug.Log("refreshed");
    } 
    public void TimePopUp() //SHOW POPUP IMAGE
    {
        StartCoroutine(Timed());
        //Debug.Log("TimePopUp");
    }
    private IEnumerator Timed()
    {
        ItemIc.gameObject.SetActive(true);
        PopIc.gameObject.SetActive(true);
        yield return new 
        WaitForSeconds(popTime);
        InterIc.SetActive(false);
        PopIc.gameObject.SetActive(false);
        //gameObject.SetActive(false);
        //Debug.Log("Collet =" + counterItem);
        if(counterItem >= 4)
        {
            SceneManager.LoadScene("Win Scene");
        }
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
        Debug.Log("Collet =" + counterItem);
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

