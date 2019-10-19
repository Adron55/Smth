using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using One_Sgp4;
using LitJson;
using System;

public class SpawnDebrisModels : MonoBehaviour
{
    public List<GameObject> debrises;
    public List<List<GameObject>> debrisInstantiated;

    public float respawnTime = 1.0f;
    private Vector2 screenBounds;
    int indexInst =0,indexDeb =0;
    float x = 0.0f, y=0.0f, z=0.0f;
    bool f = false;
    private float myradius = 15f; // globe ball radius
    private float scaleValueOfCoordinates = 1;

    private List<JsonDataToPos> jsonDataToPosComp;

    // Use this for initialization
    void Start()
    {
        jsonDataToPosComp = new List<JsonDataToPos>();


        debrisInstantiated = new List<List<GameObject>>();
        debrisInstantiated.Add(new List<GameObject>());//0
        debrisInstantiated.Add(new List<GameObject>());//1
        debrisInstantiated.Add(new List<GameObject>());//2
        debrisInstantiated.Add(new List<GameObject>());//3
        debrisInstantiated.Add(new List<GameObject>());//4
        debrisInstantiated.Add(new List<GameObject>());//5
        debrisInstantiated.Add(new List<GameObject>());//6



        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        //StartCoroutine(asteroidWave());
        TextAsset mytxtData = (TextAsset)Resources.Load("data");
        jsonDataToPosComp=convertTleToLatLon(mytxtData);

    }

    private List<JsonDataToPos> convertTleToLatLon(TextAsset mytxtData)
    {

        JsonData jsonData = JsonMapper.ToObject(mytxtData.text);

        for(int i = 0; i < jsonData.Count; i++)
        {
            JsonDataToPos jsonDataToPos = new JsonDataToPos();
            jsonDataToPos.name = jsonData[i]["name"].ToString();
            jsonDataToPos.position = placeObjectToPos((float)Convert.ToDouble(jsonData[i]["lat"].ToString()), (float)Convert.ToDouble(jsonData[i]["lon"].ToString()));
            //if (checkDataDistance(jsonDataToPos.position))
           // {
                jsonDataToPosComp.Add(jsonDataToPos);
          //  }
        }
        //Debug.Log(jsonDataToPosComp.Count);
        f = true;
        inst();

        return jsonDataToPosComp;
    }

    public bool checkDataDistance(Vector3 newComer)
    {
        for(int i = 0; i < jsonDataToPosComp.Count; i++)
        {
            if (Vector3.Distance(newComer, jsonDataToPosComp[i].position)<5)
            {
                return false;
            }
        }
        return true;
    }

    private void inst()
    {
        for (int j = 0; j < jsonDataToPosComp.Count-200; j++)
        {
            indexDeb = UnityEngine.Random.Range(0, 7);

            GameObject a = Instantiate(debrises[indexDeb]) as GameObject;

            Vector3 v3Pos = jsonDataToPosComp[j].position;

            a.transform.localScale = debrises[indexDeb].GetComponent<debrisDatas>().scaleVector;
            a.transform.SetPositionAndRotation(v3Pos, UnityEngine.Random.rotationUniform);
           // Debug.Log(Vector3.Distance(Vector3.zero, a.transform.position));
            a.SetActive(true);
        }
    }
    
    private Vector3 placeObjectToPos(float mylatitude, float mylongitude)
    {

        float xPos, yPos, zPos;
        mylatitude = Mathf.PI * mylatitude / 180;
        mylongitude = Mathf.PI * mylongitude / 180;

        // adjust position by radians	
        mylatitude -= 1.570795765134f; // subtract 90 degrees (in radians)

        // and switch z and y (since z is forward)
        xPos = (myradius) * Mathf.Sin(mylatitude) * Mathf.Cos(mylongitude);
        zPos = (myradius) * Mathf.Sin(mylatitude) * Mathf.Sin(mylongitude);
        yPos = (myradius) * Mathf.Cos(mylatitude);


        return new Vector3(xPos * scaleValueOfCoordinates, yPos * scaleValueOfCoordinates, zPos * scaleValueOfCoordinates);
    }


    private GameObject spawnEnemy(GameObject game)
    {
        GameObject a = Instantiate(game) as GameObject;

        x = UnityEngine.Random.Range(0.0f, 1.0f);
        y= UnityEngine.Random.Range(0.0f, 1.0f);
        z= UnityEngine.Random.Range(10.0f, 20.0f);

        Vector3 v3Pos = Camera.main.ViewportToWorldPoint(new Vector3(x, y,z));

        a.transform.localScale = game.GetComponent<debrisDatas>().scaleVector;
        a.transform.SetPositionAndRotation(v3Pos, UnityEngine.Random.rotationUniform);
        a.SetActive(true);

        return a;
    }
    private void activateGM(GameObject game)
    {
        x = UnityEngine.Random.Range(0.0f, 1.0f);
        y = UnityEngine.Random.Range(0.0f, 1.0f);
        z = UnityEngine.Random.Range(5.0f, 10.0f);

        Vector3 v3Pos = Camera.main.ViewportToWorldPoint(new Vector3(x, y, z));

        game.transform.localScale = game.GetComponent<debrisDatas>().scaleVector;
        game.transform.SetPositionAndRotation(v3Pos, UnityEngine.Random.rotationUniform);
        game.SetActive(true);
    }
    IEnumerator asteroidWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            indexDeb = UnityEngine.Random.Range(0,7);
            if (debrisInstantiated[indexDeb].Count < 5)
            {
                debrisInstantiated[indexDeb].Add(spawnEnemy(debrises[indexDeb]));
            }
            else
            {
                List<int> indexes=new List<int>();
                for(int j = 0; j < debrisInstantiated[indexDeb].Count; j++)
                {
                    //if (debrisInstantiated[indexDeb][j].active == false)
                    //{
                        indexes.Add(j);
                   // }
                }
                
                activateGM(debrisInstantiated[indexDeb][UnityEngine.Random.Range(0, indexes.Count)]);
            }
            
        }
    }

    [SerializeField]
    public class JsonDataToPos
    {
        public string name;
        public Vector3 position;
    }

}
