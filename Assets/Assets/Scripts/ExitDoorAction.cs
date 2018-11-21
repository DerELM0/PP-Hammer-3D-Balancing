using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoorAction : MonoBehaviour {

    public bool DoorOpen;
    public float speed;
    public int treasures;


    // Use this for initialization
    void Start()
    {
        speed = 0.02f;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.instance.ether >= treasures)
        {
            DoorOpen = true;
        }
    }

    void Update()
    {

        if (DoorOpen && transform.position.y >= -2.0f)
        {
            transform.position -= new Vector3(0.0f, speed, 0.0f);
        }
    }
}
