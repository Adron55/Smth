using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserMovement : MonoBehaviour
{
    public GameObject center;
    public GameObject ship;
    
    
    public float speed = 0.1f;
    public float defaultMoveSpeed = 4; 

    private Vector3 moveVec;



    // Start is called before the first frame update
    private void Start()
    {
       moveVec = new Vector3(0, 0, defaultMoveSpeed);
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            center.transform.eulerAngles += new Vector3(0, -speed, 0) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            center.transform.eulerAngles += new Vector3(0, speed, 0) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.W))
        {
            ship.transform.position += new Vector3(speed*Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            ship.transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        }
        moveVec = new Vector3(0, 0, defaultMoveSpeed);
        center.transform.eulerAngles += moveVec*Time.deltaTime;

    }
}
