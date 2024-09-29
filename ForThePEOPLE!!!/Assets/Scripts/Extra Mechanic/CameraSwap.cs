using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwap : MonoBehaviour
{
    public GameObject cameraTop;
    public GameObject cameraBack;
    public GameObject cameraFront;
    public GameObject flashlight, toplight, topRoof , frontlight;
    public GameObject Eflashlight, Etoplight;
    public GameObject Easter, Easter1;
    public AudioSource audioOff,notjustyou;
    public GameObject nogoingback;
    private float delay = 1f; 

    public int stateCam = 0;

    void Start()
    {
        cameraTop.SetActive(true);  // top active
        cameraBack.SetActive(false); // back inactive
        cameraFront.SetActive(false); // front active
        topRoof.SetActive(false);
        audioOff.enabled = true;
        nogoingback.SetActive(false);
        stateCam = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (stateCam == 0) 
            {
                BackCam(); //to back
            }
            if (stateCam == 1)
            {
                TopCam();  //to top
            }
            else if(stateCam == 2)
            {
                Show();
            }
            

            
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            FirstCam();  //to front
            stateCam = 2;

            if (Input.GetKey(KeyCode.C))
            {
                Show();
            }

            if (Input.GetKey(KeyCode.Backspace))
            {
                Show();
            }
        }
    }

    void BackCam()
    {
        cameraTop.SetActive(false);  // disable top
        cameraBack.SetActive(true);  // enable back
        cameraFront.SetActive(false); // disable front
        frontlight.SetActive(false);
        flashlight.SetActive(true);
        Eflashlight.SetActive(true);
        toplight.SetActive(false);
        Etoplight.SetActive(false);
        Easter.SetActive(true);
        Easter1.SetActive(true);
        stateCam = 1;  //state to back
        topRoof.SetActive(true);     
        audioOff.enabled = true;     
    }

    void TopCam()
    {
        cameraTop.SetActive(true);   // nable top
        cameraBack.SetActive(false); // disable back
        cameraFront.SetActive(false); // disable front
        frontlight.SetActive(false);
        flashlight.SetActive(false);
        Eflashlight.SetActive(false);
        toplight.SetActive(true);
        Etoplight.SetActive(true);
        Easter.SetActive(true);
        Easter1.SetActive(true);
        stateCam = 0;  //state to top
        topRoof.SetActive(false);     
        audioOff.enabled = true;    
    }

    void FirstCam()
    {
        cameraTop.SetActive(false);   // disable top
        cameraBack.SetActive(false);  // disable back
        cameraFront.SetActive(true);  // enable front
        frontlight.SetActive(true);
        flashlight.SetActive(false);
        Eflashlight.SetActive(false);
        toplight.SetActive(false);
        Etoplight.SetActive(true);
        Easter.SetActive(false);     
        Easter1.SetActive(false);
        stateCam = 2;  //state to front
        topRoof.SetActive(true);
        audioOff.enabled = false;
        notjustyou.Play();
    }

    public void Show()
    {
        StartCoroutine(Disappear());
    }
    private IEnumerator Disappear()
    {
        nogoingback.SetActive(true);
        yield return new WaitForSeconds(delay);
        nogoingback.SetActive(false);
    }
}

