using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour {
    public InputField name;
    public Text nameOFplayer;
    public GameObject alertTxt;
    public Scene main;
    public string playerName;
    public score sc;    
    public int textScore;
	// Use this for initialization
	void Start () {
        if(nameOFplayer!= null)
        {
            loadData(sc.loadScore());
        }
	}
	
	// Update is called once per frame
	void Update () {
        
    }
    public void beginBtn()
    {
        if (name.text == "")

            alertTxt.SetActive(true);

        else
        {
            DontDestroyOnLoad(GameObject.Find("Slider"));
            SceneManager.LoadScene("level 0");
            
        }


    }
    public void Quit()
    {
        Application.Quit();
    }
    public void saveData()
    {
        PlayerPrefs.SetString("playerName", name.text);
        PlayerPrefs.Save();
    }
    public void loadData(int score)
    {
        playerName ="sorry "+ PlayerPrefs.GetString("playerName")+"\n"+"you are dead"+"\n"+"your score is "+score;
        nameOFplayer.text = playerName;
    }
}
