using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDebrisModels : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;

    float x = 0.0f, y=0.0f, z=0.0f;
    // Use this for initialization
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(asteroidWave());
    }
    private void spawnEnemy()
    {
        GameObject a = Instantiate(asteroidPrefab) as GameObject;
        x=Random.Range(0f, 0.99f);
        y= Random.Range(0.75f, 0.99f);
        z= Random.Range(10.0f, 20.0f);
        Vector3 v3Pos = Camera.main.ViewportToWorldPoint(new Vector3(x, y,z));
        a.transform.localScale = new Vector3(.05f,.05f,.05f);
        a.transform.SetPositionAndRotation(v3Pos, Random.rotationUniform);

        Debug.Log(string.Format("x= {0} ; y= {1}", x, y));
        //a.transform.position = v3Pos;//new Vector3(screenBounds.x * -2, Random.Range(-screenBounds.y, screenBounds.y),Random.Range(-12,12));
    }
    IEnumerator asteroidWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
    }
}
