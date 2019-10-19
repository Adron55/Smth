using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDebrisModels : MonoBehaviour
{
    public List<GameObject> debrises;
    public List<List<GameObject>> debrisInstantiated;

    public float respawnTime = 1.0f;
    private Vector2 screenBounds;
    int indexInst =0,indexDeb =0;
    float x = 0.0f, y=0.0f, z=0.0f;
    // Use this for initialization
    void Start()
    {
        debrisInstantiated = new List<List<GameObject>>();
        debrisInstantiated.Add(new List<GameObject>());//0
        debrisInstantiated.Add(new List<GameObject>());//1
        debrisInstantiated.Add(new List<GameObject>());//2
        debrisInstantiated.Add(new List<GameObject>());//3
        debrisInstantiated.Add(new List<GameObject>());//4
        debrisInstantiated.Add(new List<GameObject>());//5
        debrisInstantiated.Add(new List<GameObject>());//6



        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(asteroidWave());
    }
    private GameObject spawnEnemy(GameObject game)
    {
        GameObject a = Instantiate(game) as GameObject;

        x =Random.Range(0f, 0.99f);
        y= Random.Range(0.75f, 0.99f);
        z= Random.Range(10.0f, 20.0f);

        Vector3 v3Pos = Camera.main.ViewportToWorldPoint(new Vector3(x, y,z));

        a.transform.localScale = game.GetComponent<debrisDatas>().scaleVector;
        a.transform.SetPositionAndRotation(v3Pos, Random.rotationUniform);
        a.SetActive(true);

        return a;
    }
    private void activateGM(GameObject game)
    {
        x = Random.Range(0f, 0.99f);
        y = Random.Range(0.75f, 0.99f);
        z = Random.Range(10.0f, 20.0f);

        Vector3 v3Pos = Camera.main.ViewportToWorldPoint(new Vector3(x, y, z));

        game.transform.localScale = game.GetComponent<debrisDatas>().scaleVector;
        game.transform.SetPositionAndRotation(v3Pos, Random.rotationUniform);
        game.SetActive(true);
    }
    IEnumerator asteroidWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            indexDeb = Random.Range(0,7);
            if (debrisInstantiated[indexDeb].Count < 5)
            {
                debrisInstantiated[indexDeb].Add(spawnEnemy(debrises[indexDeb]));
            }
            else
            {
                List<int> indexes=new List<int>();
                for(int j = 0; j < debrisInstantiated[indexDeb].Count; j++)
                {
                    if (debrisInstantiated[indexDeb][j].active == false)
                    {
                        indexes.Add(j);
                    }
                }
                
                activateGM(debrisInstantiated[indexDeb][Random.Range(0, indexes.Count)]);
            }
            
        }
    }
}
