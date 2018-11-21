using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWreckingBall : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            this.gameObject.SetActive(false);
        }
    }
}
