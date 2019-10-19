using UnityEngine;

public class UserMovement : MonoBehaviour
{
    public GameObject center;
    public GameObject ship;


    public float maxHeight = 20, minHeight = 10;


    public float speed = 0.1f;
    public float defaultMoveSpeed = 4;


    private float tempFloat;
    private Vector3 moveVec;
    private Vector3 tempVec;


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
            tempFloat = ship.transform.localPosition.x + speed * Time.deltaTime;
            ship.transform.localPosition = new Vector3(Mathf.Clamp(tempFloat, minHeight, maxHeight), ship.transform.localPosition.y, ship.transform.localPosition.z);
        }

        if (Input.GetKey(KeyCode.S))
        {
            tempFloat = ship.transform.localPosition.x - speed * Time.deltaTime;
            ship.transform.localPosition = new Vector3(Mathf.Clamp(tempFloat, minHeight, maxHeight), ship.transform.localPosition.y, ship.transform.localPosition.z);
        }


        moveVec = new Vector3(0, 0, defaultMoveSpeed);
        center.transform.eulerAngles += moveVec * Time.deltaTime;


    }
}
