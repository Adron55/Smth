using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioOn : MonoBehaviour
{
    //AudioSource audioData;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Audio On");
        stopMusic();
    }
    public void stopMusic()
    {
        var obj = GameObject.Find("Music");
        var audioData = obj.GetComponent<AudioSource>();
        audioData.Stop();
    }
}
