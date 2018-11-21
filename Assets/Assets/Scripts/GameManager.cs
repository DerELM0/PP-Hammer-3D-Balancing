using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public Text stats;
    public Text time;
    public Text inventory;
    public Text hint;

    public Image hintBackground;

    public int ether = 0;
    public int health;
    public int maxHealth;
    public float orbCountdown;
    public float orbStrength;
    public bool jumpOrbPickedUp = false;
    public int maxOrbCountdown;
    public int lives;
    public string hintMessage;
    public float hintTimer = 0;

    public Camera firstPersonCamera;
    public Camera thirdPersonCamera;

    public RawImage firstPersonView;
    public RawImage thirdPersonView;

    private AudioSource source;
    public AudioClip deathSound;
    public AudioClip gameOverSound;

    public RectTransform currentHealth;
    public RectTransform currentOrbCountdown;

    public List<GameObject> inventoryList;
    public static GameManager instance;

    Animator anim;
    

    private void Start()
    {
        
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {        
        
        if (orbCountdown > 0 && jumpOrbPickedUp)
        {
            orbCountdown -= Time.deltaTime;
            source.Pause();
        }
        else if (orbCountdown <= 0 && jumpOrbPickedUp)
        {
            GameObject.FindWithTag("Player").GetComponent<CharacterMove>().jumpSpeed = 5;
            jumpOrbPickedUp = false;
            orbCountdown = 0;
            source.UnPause();
        }

        if (firstPersonCamera.isActiveAndEnabled)
        {
            firstPersonView.enabled = true;
            thirdPersonView.enabled = false;
        }

        else if (thirdPersonCamera.isActiveAndEnabled)
        {
            firstPersonView.enabled = false;
            thirdPersonView.enabled = true;
        }

        if(hintBackground.enabled == true)
        {
            hintTimer -= Time.deltaTime;
            if(hintTimer <= 0)
            {
                hintBackground.enabled = false;
                hint.text = "";
            }
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            anim = GetComponentInChildren<Animator>();
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        if (PlayerPrefs.GetString("Laden?") == "Ja")
        {
            GameManager.instance.health = PlayerPrefs.GetInt("Health");
            GameManager.instance.ether = PlayerPrefs.GetInt("Ethereum");
            GameManager.instance.lives = PlayerPrefs.GetInt("Lives");
        }
        else
        {
            health = 80;
        }
    }

    void OnGUI()
    {
        stats.text = "Ethereum: " + ether.ToString() + "\n" + "Lives: " + lives.ToString();
        inventory.text = "Inventory:";
        foreach (GameObject item in inventoryList)
        {
            if(item != null)
            {
                inventory.text += "\n" + item.tag;
            }            
        } 
       
        currentHealth.localScale = new Vector3((float)health / maxHealth, 1, 1);
        currentOrbCountdown.localScale = new Vector3(orbCountdown/maxOrbCountdown, 1, 1);        
    }

    public void ShowHint(string toShow, float timerFromHint)
    {
        hintTimer = timerFromHint;
        hintBackground.enabled = true;
        hint.text = toShow;
    }
    
    public void Die()
    {
        if(lives >= 1)
        {
            lives -= 1;
            if (lives == 0)
            {
                anim.SetTrigger("GameOver");
                GameObject.Find("Player").GetComponent<CharacterMove>().enabled = false;
                GameObject.Find("Player").GetComponent<AudioSource>().PlayOneShot(gameOverSound);
            }
            else if (lives > 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                source.PlayOneShot(deathSound);
                health = 80;
                GameObject.FindWithTag("Player").GetComponent<CharacterMove>().jumpSpeed = 5;
                jumpOrbPickedUp = false;
                orbCountdown = 0;
            }
        }          
    }
}
