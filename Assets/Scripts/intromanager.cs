using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class IntroManager : MonoBehaviour
{
    public VideoPlayer videoPlayer; 
    public string gameSceneName = "GameScene"; 

    void Start()
    {
        
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached += OnIntroEnd;
            videoPlayer.Play();
        }
    }

    void OnIntroEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene(gameSceneName);
    }
}
