using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opensesami : MonoBehaviour
{
    public GameObject DoorCld, DoorOP, DoorIc;
    public AudioSource soundOpen;
    private bool Opened= false;
    
    // Start is called before the first frame update
    void Start()
    {
        //soundOpen.enabled = false;
    }
    void OnTriggerStay(Collider other)
    {
        if(Opened == false)
        {
            if(other.CompareTag("TrigDoor"))
            {
                DoorIc.SetActive(true);
                if(Input.GetKeyDown(KeyCode.E))
                {
                    DoorIc.SetActive(false);
                     DoorCld.SetActive(false);
                     DoorOP.SetActive(true);
                     Opened = true;
                     soundOpen.Play();
                }
                if(Input.GetKey(KeyCode.E))
                {
                    DoorIc.SetActive(false);
                    DoorCld.SetActive(false);
                    DoorOP.SetActive(true);
                    Opened = true;
                    soundOpen.Play();
                }
            }
        }       
            
            
    }
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("TrigDoor"))
        {
            DoorIc.SetActive(false);
            Start();
            Debug.Log("Door Refreshed");
        }
    }
}
