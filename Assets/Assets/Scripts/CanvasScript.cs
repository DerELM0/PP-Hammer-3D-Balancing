using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour {

    public Camera firstPersonView;
    public Camera thirdPersonView;
    public bool camSwitch = false;
    public Transform loadGameButton;

    public void LoadScene(string sceneName)
    {
        Destroy(GameObject.Find("GameManager"));
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void LoadMainMenu()
    {
        Destroy(GameObject.Find("GameManager"));
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
    public void ToggleCamera()
    {
        camSwitch = !camSwitch;
        firstPersonView.enabled = camSwitch;
        thirdPersonView.enabled = !camSwitch;
        EventSystem.current.SetSelectedGameObject(null);
    }
    public void SaveGame()
    {
        PlayerPrefs.SetInt("Health", GameManager.instance.health);
        PlayerPrefs.SetInt("Ethereum", GameManager.instance.ether);
        PlayerPrefs.SetString("Scene", SceneManager.GetActiveScene().name);
        PlayerPrefs.SetInt("Lives", GameManager.instance.lives);
        PlayerPrefs.SetFloat("Player_X", GameObject.FindWithTag("Player").transform.position.x);
        PlayerPrefs.SetFloat("Player_Y", GameObject.FindWithTag("Player").transform.position.y);
        PlayerPrefs.SetFloat("Player_Z", GameObject.FindWithTag("Player").transform.position.z);
        PlayerPrefs.SetFloat("PlayerDirection_X", GameObject.FindWithTag("Player").transform.forward.x);
        PlayerPrefs.SetFloat("PlayerDirection_Y", GameObject.FindWithTag("Player").transform.forward.y);
        PlayerPrefs.SetFloat("PlayerDirection_Z", GameObject.FindWithTag("Player").transform.forward.z);
        PlayerPrefs.Save();
        
    }
    public void LoadGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("Scene"));        
        PlayerPrefs.SetString("Laden?", "Ja");        
    }
    private void Update()
    {
        if (PlayerPrefs.GetInt("Health") != 0)
        {
            loadGameButton.GetComponent<Button>().interactable = true;
        }
        else
        {
            loadGameButton.GetComponent<Button>().interactable = false;
        }
    }
}
