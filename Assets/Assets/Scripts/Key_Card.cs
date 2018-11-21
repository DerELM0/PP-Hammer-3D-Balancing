using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_Card : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {        
        GameManager.instance.inventoryList.Add(this.gameObject);
        this.gameObject.SetActive(false);
    }
}
