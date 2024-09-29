using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialOpensesami : MonoBehaviour
{
    public GameObject DoorCld, DoorOP, DoorIc;
    public AudioSource openSound;
    private bool Opened= false;
    
    // Start is called before the first frame update
    void Start()
    {
        //openSound.enabled = false;
    }
    void OnTriggerStay(Collider other)
    {
        if(Opened == false)
        {
            if(other.CompareTag("SpecialTrigDoor"))
            {
                DoorIc.SetActive(true);
                if(Input.GetKeyDown(KeyCode.E))
                {
                    DoorIc.SetActive(false);
                     DoorCld.SetActive(false);
                     DoorOP.SetActive(true);
                     Opened = true;
                     openSound.Play();
                }
                if(Input.GetKey(KeyCode.E))
                {
                    DoorIc.SetActive(false);
                    DoorCld.SetActive(false);
                    DoorOP.SetActive(true);
                    Opened = true;
                    openSound.Play();
                }
            }
        }       
            
            
    }
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("SpecialTrigDoor"))
        {
            DoorIc.SetActive(false);
        }
    }
        
    
}
