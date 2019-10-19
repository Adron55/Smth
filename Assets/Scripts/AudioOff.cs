using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioOff : MonoBehaviour
{
    //AudioSource audioData;
    // Start is called before the first frame update
    private GameObject obj1;
    //void Start()
    //{
    //    Debug.Log("Audio On");
    //    var obj1 = GameObject.Find("Music On");
    //    stopMusic();
    //}
    public void stopMusic()
    {
        var obj = GameObject.Find("Music");
        var audioData = obj.GetComponent<AudioSource>();
        audioData.Pause();
    }
    public void Update()
    {
        var obj1 = GameObject.Find("Music_off");

        if (obj1.activeSelf)
        {
            stopMusic();
        }
        else
        {
            return;
        }
    }
}
