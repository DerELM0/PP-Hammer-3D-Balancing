using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneScript : MonoBehaviour {

    float characterSpeed;
    float characterRotation;
    float characterJump;
    float countdown;
    public GameObject HUD;


	void Start () {
        HUD.SetActive(false);
        characterSpeed = GameObject.FindWithTag("Player").GetComponent<CharacterMove>().moveSpeed;
        characterRotation = GameObject.FindWithTag("Player").GetComponent<CharacterMove>().rotateSpeed;
        characterJump = GameObject.FindWithTag("Player").GetComponent<CharacterMove>().jumpSpeed;
        GameObject.FindWithTag("Player").GetComponent<CharacterMove>().moveSpeed = 0;
        GameObject.FindWithTag("Player").GetComponent<CharacterMove>().rotateSpeed = 0;
        GameObject.FindWithTag("Player").GetComponent<CharacterMove>().jumpSpeed = 0;

    }
	
	
	void Update () {
        countdown += Time.deltaTime;
        if(countdown >= 16.3)
        {
            GameObject.FindWithTag("Player").GetComponent<CharacterMove>().moveSpeed = characterSpeed;
            GameObject.FindWithTag("Player").GetComponent<CharacterMove>().rotateSpeed = characterRotation;
            GameObject.FindWithTag("Player").GetComponent<CharacterMove>().jumpSpeed = characterJump;
            HUD.SetActive(true);
            this.gameObject.GetComponent<Camera>().enabled = false;
            this.gameObject.GetComponent<CutsceneScript>().enabled = false;
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            GameObject.FindWithTag("Player").GetComponent<CharacterMove>().moveSpeed = characterSpeed;
            GameObject.FindWithTag("Player").GetComponent<CharacterMove>().rotateSpeed = characterRotation;
            GameObject.FindWithTag("Player").GetComponent<CharacterMove>().jumpSpeed = characterJump;
            HUD.SetActive(true);
            this.gameObject.GetComponent<Camera>().enabled = false;
            this.gameObject.GetComponent<CutsceneScript>().enabled = false;
        }
	}
}
