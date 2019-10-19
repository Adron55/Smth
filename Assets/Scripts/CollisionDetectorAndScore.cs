using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollisionDetectorAndScore : MonoBehaviour
{
    public GameObject managerGame;
    public TextMeshProUGUI textMeshScore;

    
    [SerializeField]
    private float speedOfOpening = 0.1f;

    float timeVal = 0;
    private int scores=0;
    private Vector3 vector3Scale = new Vector3(10.66f, 5.620002f, 5.01f);//to open web to collect objects


    private void Update()
    {
        timeVal += Time.deltaTime;
        if (timeVal > 3)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, vector3Scale, speedOfOpening * Time.deltaTime);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        scores += collision.collider.gameObject.GetComponent<debrisDatas>().massOfDebris;
        collision.collider.gameObject.SetActive(false);
        textMeshScore.text = scores.ToString();
        managerGame.GetComponent<SpawnDebrisModels>().callObjectFromPool();
    }

}
