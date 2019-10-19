using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollisionDetectorAndScore : MonoBehaviour
{
    public TextMeshProUGUI textMeshScore;

    private int scores=0;

    public void OnCollisionEnter(Collision collision)
    {
        scores += collision.collider.gameObject.GetComponent<debrisDatas>().massOfDebris;
        collision.collider.gameObject.SetActive(false);
        textMeshScore.text = scores.ToString();
    }

}
