using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_On : MonoBehaviour
{
    AudioSource audioData;


    public void startMusic()
    {
        var obj = GameObject.Find("Music");
        var audioData = obj.GetComponent<AudioSource>();
        if (!audioData.isPlaying)
        {
            audioData.Play();
        }

    }
    // Update is called once per frame
    void Update()
    {
        var obj2 = GameObject.Find("Music_on");
        if (obj2.activeSelf)
        {
            Debug.Log("Girdi");
            //var obj3 = GameObject.Find("Music");
            //audioData = obj3.GetComponent<AudioSource>();
            //audioData.Play();
            startMusic();
        }
        else { return; }

    }
}
