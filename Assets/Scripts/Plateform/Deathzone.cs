using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Deathzone : MonoBehaviour
{
    public Vector3 respawnPositions;

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.tag == "player")
        {
            other.transform.position = respawnPositions;
        }
    }
}
