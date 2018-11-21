using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onHitDanger : MonoBehaviour {

    public int damage = 1;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" && GameManager.instance.health >= 1)
        {
            GameManager.instance.health -= damage;
            if(GameManager.instance.health <= 0)
            {
                GameManager.instance.Die();
            }
            Destroy(this.gameObject);
        }
    }
}
