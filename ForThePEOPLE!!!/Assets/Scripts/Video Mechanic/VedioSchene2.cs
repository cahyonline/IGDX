using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class VedioSchene2 : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject videoPart;
    public AudioSource audioSource;
    //public StartGameKeyBlocker startGame;
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.loopPointReached += OnVideoEnd;
        audioSource.enabled = false;
    }

    // Update is called once per frame
    void OnVideoEnd(VideoPlayer vp)
    {
        audioSource.enabled = true;
        videoPart.SetActive(false);
        audioSource.enabled = true;
    }
}
