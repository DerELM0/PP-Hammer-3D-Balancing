using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingObject : MonoBehaviour {

    private Transform player;
    public float range = 15.0f;
    public float bulletImpulse = 20.0f;

    public bool onRange = false;
    private Transform dir;

    public Rigidbody projectile;

    void Start()
    {
        InvokeRepeating("Shoot", 2, 1.5f);
        player = GameObject.FindWithTag("Player").transform;
    }

    void Shoot()
    {

        if (onRange)
        {

            Rigidbody bullet = (Rigidbody)Instantiate(projectile, transform.position + transform.forward, transform.rotation);
            bullet.AddForce((player.transform.position - transform.position) * bulletImpulse, ForceMode.Impulse);

            Destroy(bullet.gameObject, 2);
        }


    }

    void Update()
    {        
        onRange = Vector3.Distance(transform.position, player.position) < range;

    }

}
