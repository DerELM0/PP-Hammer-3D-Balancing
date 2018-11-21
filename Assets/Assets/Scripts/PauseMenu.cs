using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public Transform pauseCanvas;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) {                    
            if(pauseCanvas.gameObject.activeInHierarchy == false)
            {
                pauseCanvas.gameObject.SetActive(true);
                Time.timeScale = 0;                
            }
            else
            {
                pauseCanvas.gameObject.SetActive(false);
                Time.timeScale = 1;
            }        
        }        
    }
}
