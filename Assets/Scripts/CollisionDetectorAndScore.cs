using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetectorAndScore : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.gameObject.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
    }
}
