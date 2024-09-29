using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlaya : MonoBehaviour
{
    public AudioSource footSteps, runSteps;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.D))
        {
            if(Input.GetKey(KeyCode.LeftShift))
            {
                footSteps.enabled = false;
                runSteps.enabled = true;
                //Debug.Log("RUN SOUNDS");
            }
            else
            {
                footSteps.enabled = true;
                runSteps.enabled = false;
                //Debug.Log("Walk SOUNDS");
            }
        }
        else
        {
            footSteps.enabled = false;
            runSteps.enabled = false;
        }
    }
}
