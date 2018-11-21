using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpikes : MonoBehaviour {

    bool triggered;
    float movement;
    public float speed;
    private AudioSource source;
    public AudioClip spikeSound;
    // Use this for initialization
    void Start () {
        triggered = false;
        source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		if (triggered && movement <= 0.45f)
        {
            this.transform.parent.position += new Vector3(0.0f, speed, 0.0f);
            movement += speed;
        }
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && triggered == false)
        {
            triggered = true;
            source.PlayOneShot(spikeSound);
        }
    }
}
