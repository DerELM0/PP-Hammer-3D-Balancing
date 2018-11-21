using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Orb : MonoBehaviour {

    public int restoration;
    public AudioClip healthSound;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && GameManager.instance.inventoryList.Count <= 5)
        {
            GameManager.instance.inventoryList.Add(this.gameObject);
            this.gameObject.SetActive(false);
        }            
    }

    public void UseHealthPotion()
    {
        GameObject.FindWithTag("Player").GetComponent<AudioSource>().PlayOneShot(healthSound);
        GameManager.instance.health += restoration;
        if (GameManager.instance.health >= GameManager.instance.maxHealth)
        {
            GameManager.instance.health = GameManager.instance.maxHealth;
        }
    }
}
