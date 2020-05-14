using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class FirstVideo : MonoBehaviour
{
    public VideoPlayer VideoPlayer; // Drag & Drop the GameObject holding the VideoPlayer component
    public string SceneName;
    void Start()
    {
        VideoPlayer.loopPointReached += LoadScene;
    }
    void LoadScene(VideoPlayer vp)
    {
        StartCoroutine(LoadNext());
    }

IEnumerator LoadNext()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneName);
    }
}

