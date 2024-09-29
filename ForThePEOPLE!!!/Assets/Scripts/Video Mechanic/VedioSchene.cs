using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using System.Xml.Serialization;

public class VedioSchene : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public ManagerofScenes managerer;
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    // Update is called once per frame

     void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneSkip();
        }    
    }
    void OnVideoEnd(VideoPlayer vp)
    {
        SceneSkip();
    }

    void SceneSkip()
    {
        managerer.ToMainmenu();
    }
}
