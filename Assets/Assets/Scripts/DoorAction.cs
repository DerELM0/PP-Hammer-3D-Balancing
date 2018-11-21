using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAction : MonoBehaviour {

    public bool DoorOpen;    
    public float speed;
    

    // Use this for initialization
    void Start () {        
        speed = 0.02f;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        for(int i=0;i < GameManager.instance.inventoryList.Count;i++)
        {
            if(GameManager.instance.inventoryList[i].tag == this.gameObject.tag)
            {
                DoorOpen = true;
                GameManager.instance.inventoryList.RemoveAt(i);
            }
        }
    }

    void Update () {

		if(DoorOpen && transform.position.y >= -2.0f)
        {
            transform.position -= new Vector3(0.0f, speed, 0.0f);
        }
	}
}
