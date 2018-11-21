using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppingStone : MonoBehaviour {

    bool triggered;
    bool isGrounded;

	// Use this for initialization
	void Start () {
        triggered = false;
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && triggered == false)
        {
            this.gameObject.GetComponent<Rigidbody>().useGravity = true;
            triggered = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && this.gameObject.GetComponent<Rigidbody>().useGravity == true)
        {
            GameManager.instance.Die();
        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (triggered == true && this.gameObject.GetComponent<Rigidbody>().velocity.magnitude == 0 && this.gameObject.GetComponent<Rigidbody>().IsSleeping())
        {
            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            this.gameObject.GetComponent<Rigidbody>().useGravity = false;
        }

    }



    
}
