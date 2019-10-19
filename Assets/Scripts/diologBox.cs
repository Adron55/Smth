using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class diologBox : MonoBehaviour
{


    public string targetText;


    public float maxTime, tempTime;
    public TMP_Text funFact;

    int textInd = 0;
    int textLength;

    string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
    string tempS;
    string reveleadText = "";
    
    System.Random random = new System.Random();


    // Start is called before the first frame update
    void Start()
    {
        textLength = targetText.Length;
    }

    // Update is called once per frame
    void Update()
    {
        tempTime += Time.deltaTime;
        if (tempTime >= maxTime)
        {
            tempTime = 0;

            reveleadText += targetText[textInd];
            textInd += 1;
            textLength -= 1;
        }
        else
        {
            tempS = "";
            for (int i = 0; i < textLength; i++)
            {
                tempS += chars[random.Next(chars.Length)];
            }

            funFact.text = reveleadText + tempS;
        }
    }
}
