using UnityEngine;

public class UserMovement : MonoBehaviour
{
    public GameObject center;
    public GameObject ship;
    public GameObject holder;


    public float maxHeight = 18, minHeight = 10;


    public float speed = 0.1f;
    public float defaultMoveSpeed = 4;
    public float norm = 0.1f;

    private float tempFloat;
    private Vector3 moveVec;
    private Vector3 tempVec;


    // Start is called before the first frame update
    private void Start()
    {
        moveVec = new Vector3(0, 0, defaultMoveSpeed);
        Debug.Log(holder.transform.localRotation.x);
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            center.transform.eulerAngles += new Vector3(0, -speed, 0) * Time.deltaTime;
            if (holder.transform.localRotation.x <0.1f)
            {
                holder.transform.Rotate(1, 0, 0, Space.Self);
            }
        }
        else if (holder.transform.localRotation.x > 0f)
        {
            Debug.Log("here");
            holder.transform.Rotate(Mathf.Min(-1, -holder.transform.localRotation.x), 0, 0, Space.Self);
        }
        
       
        if (Input.GetKey(KeyCode.A))
        {
            center.transform.eulerAngles += new Vector3(0, speed, 0) * Time.deltaTime;
            Debug.Log("rOTATION"+holder.transform.localRotation.x);
            if(holder.transform.localRotation.x > -0.1f)
            {
                holder.transform.Rotate(-1, 0, 0, Space.Self);
            }
        }
        else if (holder.transform.localRotation.x < 0f)
        {
            Debug.Log("here");
            holder.transform.Rotate(Mathf.Max(1, -holder.transform.localRotation.x), 0, 0, Space.Self);
        }

        if (Input.GetKey(KeyCode.W))
        {
            //Debug.Log(Mathf.Clamp(tempFloat, minHeight, maxHeight));
            if (Mathf.Clamp(tempFloat, minHeight, maxHeight) <maxHeight)
            {
                tempFloat = ship.transform.localPosition.x + speed * Time.deltaTime*norm;
                ship.transform.localPosition = new Vector3(Mathf.Clamp(tempFloat, minHeight, maxHeight), ship.transform.localPosition.y, ship.transform.localPosition.z);
                holder.transform.Rotate(0, 0, -1, Space.Self);
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            //Debug.Log(Mathf.Clamp(tempFloat, minHeight, maxHeight));
            if (Mathf.Clamp(tempFloat, minHeight, maxHeight) > minHeight)
            {
                tempFloat = ship.transform.localPosition.x - speed * Time.deltaTime*norm;
                ship.transform.localPosition = new Vector3(Mathf.Clamp(tempFloat, minHeight, maxHeight), ship.transform.localPosition.y, ship.transform.localPosition.z);
                holder.transform.Rotate(0, 0, 1, Space.Self);
            }
        }


        moveVec = new Vector3(0, 0, defaultMoveSpeed);
        center.transform.eulerAngles += moveVec * Time.deltaTime;


    }
}
