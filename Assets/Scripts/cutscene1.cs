using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    public VideoPlayer videoPlayer; 
    public string nextSceneName; 

    void Start()
    {
        if (videoPlayer != null)
        {
            videoPlayer.Play(); 
            videoPlayer.loopPointReached += OnVideoEnd; 
        }
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene(nextSceneName); 
    }
}

