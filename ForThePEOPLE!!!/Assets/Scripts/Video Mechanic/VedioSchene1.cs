using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class VedioSchene1 : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public ManagerofScenes managerer;
    //public StartGameKeyBlocker startGame;
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.loopPointReached += OnVideoEnd;
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneSkip();
        } 
    }

     void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneSkip();
        }    
    }
    // Update is called once per frame
    void OnVideoEnd(VideoPlayer vp)
    {
        SceneSkip();
        //startGame.Start();
    }

    void SceneSkip()
    {
        managerer.ToGame();
    }
}
