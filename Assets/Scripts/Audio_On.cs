using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_On : MonoBehaviour
{
    AudioSource audioData;

    // Update is called once per frame
    void Update()
    {
        var obj2 = GameObject.Find("Music_on");
        if (obj2.activeSelf)
        {
            var obj3 = GameObject.Find("Music");
            audioData = obj3.GetComponent<AudioSource>();
            audioData.Stop();
        }

    }
}
