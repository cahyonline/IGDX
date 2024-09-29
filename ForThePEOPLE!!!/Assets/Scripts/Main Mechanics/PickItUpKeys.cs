using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickItUpKeys : MonoBehaviour
{
    public GameObject ItemIc , InterIc , PopIc;
    private float popTime = 1f;
    private float DelaySeconds = 2f;
    public MeshRenderer meshRenderer;
    public GameObject SpecialDoorTrig;
    public int Keys=0;

    public AudioSource pickSound;
    // Start is called before the first frame update
    void Start()
    {
        DelayStart();
        ItemIc.SetActive(false);
        InterIc.SetActive(false);
        PopIc.SetActive(false);
        //pickSound.enabled = false;
        SpecialDoorTrig.SetActive(false);
    }
    void OnTriggerStay(Collider other) //INSIDE SHOW INTERIC
    {
        if(other.CompareTag("TrigDoor"))
        //Debug.Log("inside");
        {
            InterIc.SetActive(true);
            if(Input.GetKey(KeyCode.E))
            {   
                TimePopUp();
                meshRenderer.enabled = false;
                InterIc.SetActive(false);
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

    public void Refresher()
    {
        Start();
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
        SpecialDoorTrig.SetActive(true);
        yield return new 
        WaitForSeconds(popTime);
        Keys = Keys + 1;
        InterIc.SetActive(false);
        PopIc.gameObject.SetActive(false);
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

