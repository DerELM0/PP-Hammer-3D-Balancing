using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckingBall : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && this.gameObject.GetComponent<Rigidbody>().useGravity == true)
        {
            GameManager.instance.Die();           
        }
    }

    private void FixedUpdate()
    {
        if(this.gameObject.GetComponent<Rigidbody>().IsSleeping())
        {
            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            this.gameObject.GetComponent<Rigidbody>().useGravity = false;
        }
    }
}
