using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timelimit : MonoBehaviour {


    public float timelimit;
    float countdown;

    
	// Use this for initialization
	void Start () {
        countdown = timelimit;
	}



    // Update is called once per frame
    void Update () {
        countdown -= Time.deltaTime;
        GameManager.instance.time.text = (Mathf.Round(countdown)).ToString();

        if (countdown <= 0)
        {
            GameManager.instance.Die();
            countdown = timelimit;
        }
	}
}
