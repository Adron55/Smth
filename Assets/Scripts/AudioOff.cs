using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioOff : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Audio Off");
        startMusic();
    }
    public void startMusic()
    {
        var obj = GameObject.Find("Music");
        var audioData = obj.GetComponent<AudioSource>();
        audioData.Play(0);
    }
}
