using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemovableBlock : MonoBehaviour {

    public int respawnTime;
    public bool removed;
    float countdown;

	// Use this for initialization
	void Start () {
        countdown = respawnTime;
        removed = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(removed == true)
        {
            this.gameObject.GetComponent<Renderer>().enabled = false;
            this.gameObject.GetComponents<BoxCollider>()[0].enabled = false;
            this.gameObject.GetComponents<BoxCollider>()[1].enabled = false;
            countdown -= Time.deltaTime;
            if(countdown <= 0)
            {
                removed = false;
                countdown = respawnTime;
                this.gameObject.GetComponent<Renderer>().enabled = true;
                this.gameObject.GetComponents<BoxCollider>()[0].enabled = true;
                this.gameObject.GetComponents<BoxCollider>()[1].enabled = true;
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.instance.Die();
        }
    }
}
