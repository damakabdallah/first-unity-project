using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour {
    public GameObject menuPause;
    bool gameInPause;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (gameInPause)
                resume();
            else
                pause();
        }
	}
    public void loadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("main menu");
    }
    public void pause()
    {
        menuPause.SetActive(true);
        Time.timeScale = 0;
        gameInPause = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void resume()
    {
        menuPause.SetActive(false);
        Time.timeScale = 1;
        gameInPause = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

}
