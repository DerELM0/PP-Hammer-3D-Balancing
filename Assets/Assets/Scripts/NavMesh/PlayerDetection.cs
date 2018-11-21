using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GetComponentInParent<NavMeshAgressiveScript>().playerInSight = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            GetComponentInParent<NavMeshAgressiveScript>().playerInSight = false;
        }
    }
}
