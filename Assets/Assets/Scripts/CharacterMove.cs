using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour {

	public float moveSpeed;
	public float rotateSpeed;
	public float jumpSpeed;
    public bool hammering;
    public Transform hammerPoint;
    public float hammeringHeight;
    public Light flashlight;

    public Camera firstPersonView;
    public Camera thirdPersonView;
    public bool camSwitch = false;

    float countdown;

    bool isGrounded;
    bool onLadder;
    

	// Use this for initialization
	void Start () {
        GameManager.instance.firstPersonCamera = firstPersonView;
        GameManager.instance.thirdPersonCamera = thirdPersonView;
        GameObject.Find("MenuButtons").GetComponent<CanvasScript>().firstPersonView = firstPersonView;
        GameObject.Find("MenuButtons").GetComponent<CanvasScript>().thirdPersonView = thirdPersonView;
        if (PlayerPrefs.GetFloat("Player_X") != 0 && PlayerPrefs.GetFloat("Player_Y") != 0 && PlayerPrefs.GetFloat("Player_Z") != 0 && PlayerPrefs.GetString("Laden?") == "Ja")
        {
            transform.position = new Vector3(PlayerPrefs.GetFloat("Player_X"), PlayerPrefs.GetFloat("Player_Y"), PlayerPrefs.GetFloat("Player_Z"));
            transform.forward = new Vector3(PlayerPrefs.GetFloat("PlayerDirection_X"), PlayerPrefs.GetFloat("PlayerDirection_Y"), PlayerPrefs.GetFloat("PlayerDirection_Z"));
            PlayerPrefs.DeleteAll();
        }
	}

	// FixedUpdate is called once per frame for Physics updates
	void FixedUpdate () {
		// check ground
		isGrounded = Physics.Raycast (transform.position, -transform.up, transform.localScale.y + 0.1f);

        // ray for hammering
        RaycastHit hit;
        Ray hammeringRay = new Ray(hammerPoint.position, Vector3.down);
        

		// input
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");

        if (onLadder && !Input.GetButton("Fire1"))
        {
            // movement            
            transform.Rotate(Vector3.up * h * rotateSpeed * Time.deltaTime);
            transform.Translate(new Vector3(0, v, 0) * Time.deltaTime * moveSpeed);
        }

        else if ( !Input.GetButton ("Fire1") ) {
			// movement
			transform.Rotate (Vector3.up * h * rotateSpeed * Time.deltaTime);
			transform.Translate (new Vector3 (0, 0, v) * Time.deltaTime * moveSpeed);
            transform.Find("Jackhammer").gameObject.SetActive(false);
            countdown = 1;
            hammering = false;
        }
        
        if ( isGrounded && Physics.Raycast(hammeringRay, out hit, hammeringHeight) && Input.GetButton("Fire1") ) {
            if (hit.collider.tag == "RemovableBlock") {
                if(hammering == false)
                {
                    hammering = true;                    
                }
                if (hammering == true)
                {
                    transform.Find("Jackhammer").gameObject.SetActive(true);
                    countdown -= Time.deltaTime;
                    if(countdown <= 0)
                    {
                        hit.collider.GetComponent<RemovableBlock>().removed = true;
                        hammering = false;
                        transform.Find("Jackhammer").gameObject.SetActive(false);
                    }
                }
            }                        
		}
        // jump
        if ( Input.GetButtonDown("Jump") && isGrounded) {
		    GetComponent<Rigidbody>().AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        }
        // TODO duck
    }

    private void Update()        
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            camSwitch = !camSwitch;
            firstPersonView.enabled = camSwitch;
            thirdPersonView.enabled = !camSwitch;
        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            if (flashlight.enabled == true)
            {
                flashlight.enabled = false;
            }
            else
            {
                flashlight.enabled = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.F1))
        {
            for (int i = 0; i < GameManager.instance.inventoryList.Count; i++)
            {
                if (GameManager.instance.inventoryList[i].tag == "Health Pack")
                {
                    GameManager.instance.inventoryList[i].GetComponent<Health_Orb>().UseHealthPotion();
                    GameManager.instance.inventoryList.RemoveAt(i);
                }
            }
        }
        if(Input.GetKeyDown(KeyCode.F2))
        {
            for (int i = 0; i < GameManager.instance.inventoryList.Count; i++)
            {
                if (GameManager.instance.inventoryList[i].tag == "Jump Potion")
                {
                    GameManager.instance.inventoryList[i].GetComponent<Jump_Orb>().UseJumpPotion();
                    GameManager.instance.inventoryList.RemoveAt(i);
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ladder"))
        {
            onLadder = true;
            GetComponent<Rigidbody>().useGravity = false;
        }
        if (other.gameObject.CompareTag("Item"))
        {
            other.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ladder"))
        {
            onLadder = false;
            GetComponent<Rigidbody>().useGravity = true;

        }
    }
}
