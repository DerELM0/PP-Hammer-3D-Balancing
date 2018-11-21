using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour {

    public string nextLevel;

    private void OnTriggerEnter(Collider other)
    {
        Destroy(GameObject.Find("GameManager"));
        SceneManager.LoadScene(nextLevel);        
    }
}
