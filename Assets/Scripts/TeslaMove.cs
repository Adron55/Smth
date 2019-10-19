using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeslaMove : MonoBehaviour
{
    float x = 0.0f, y = 0.0f, z = 0.0f;
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        spawnEnemy(obj);
    }

    private GameObject spawnEnemy(GameObject game)
    {
        //GameObject a = Instantiate(game) as GameObject;

        x = Random.Range(0f, 0.99f);
        y = Random.Range(0.75f, 0.99f);
        z = Random.Range(10.0f, 20.0f);

        Vector3 v3Pos = Camera.main.ViewportToWorldPoint(new Vector3(x, y, z));

        //obj.transform.localScale = v3Pos;
        obj.transform.position = v3Pos;
        //a.transform.SetPositionAndRotation(v3Pos, Random.rotationUniform);
        //a.SetActive(true);

        return obj;
    }
}
