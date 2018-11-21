using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_Orb : MonoBehaviour {

    public float duration;
    public int strength;
    public AudioClip jumpSound;
	
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && GameManager.instance.inventoryList.Count <= 5)
        {
            GameManager.instance.inventoryList.Add(this.gameObject);
            this.gameObject.SetActive(false);
        }               
    }

    public void UseJumpPotion()
    {
        GameObject.FindWithTag("Player").GetComponent<AudioSource>().PlayOneShot(jumpSound);
        GameObject.FindWithTag("Player").GetComponent<CharacterMove>().jumpSpeed += strength;
        GameManager.instance.orbCountdown = duration;
        GameManager.instance.orbStrength = strength;
        GameManager.instance.jumpOrbPickedUp = true;
    }
}
