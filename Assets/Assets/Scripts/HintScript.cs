using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintScript : MonoBehaviour {

    public string hintText;
    public float hintTimer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.instance.ShowHint(hintText, hintTimer);
            this.gameObject.SetActive(false);
        }
    }
}
