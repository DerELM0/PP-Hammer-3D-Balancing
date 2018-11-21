using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureScript : MonoBehaviour {

    public AudioClip treasureSound;
    public int value;

    private void Update()
    {
        transform.Rotate(Vector3.up * (Time.deltaTime*60));
    }

    private void OnTriggerEnter(Collider other)
    {
        {
            if(other.gameObject.tag == "Player")
            {
                GameManager.instance.ether += value;
                other.GetComponent<AudioSource>().PlayOneShot(treasureSound);
                this.gameObject.SetActive(false);
            }
        }
    }
}
