using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour {

    public float strength;
    private Vector3 target;
    private Vector3 moveDir;
    private Rigidbody rb;

	void Start () {
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {        
        target = transform.Find("target").position;
    }

    void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {            
            rb = collision.gameObject.GetComponent<Rigidbody>();
            moveDir = (target - rb.position).normalized;
            rb.transform.position += moveDir * strength * Time.deltaTime;
        }
    }
}