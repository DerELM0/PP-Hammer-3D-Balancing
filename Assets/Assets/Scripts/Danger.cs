using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danger : MonoBehaviour {

    public int damage = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && GameManager.instance.health >= 1)
        {
            GameManager.instance.health -= damage;
        }
        else if (GameManager.instance.health == 0)
        {
            GameManager.instance.Die();
        }
    }
}
