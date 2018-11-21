using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {

    public Transform Destination;
    private AudioSource source;
    public AudioClip Teleporter_Sound;

	void Start () {
        source = GetComponent<AudioSource>();
	}
	
	
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.position = Destination.transform.position;
            other.transform.rotation = Destination.transform.rotation;
            source.PlayOneShot(Teleporter_Sound);
        }
    }
}
