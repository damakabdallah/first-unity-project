using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour {
	Ammo Ammo;
	CharacterWeapons chw;
	zombieHealth zh;
	public Text scoreText;
	public int allScore=0;
    public int finalScore = 0;
	// Use this for initialization
	void Start () {
		chw= GetComponent<CharacterWeapons>();
		Ammo = chw.weapON.GetComponent<Ammo>();
		scoreText.text ="score : "+allScore;
        
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 100f)&&Ammo.ammo!=0)
          if(hit.transform.tag=="enemy")
          {
            zh =hit.transform.GetComponent<zombieHealth>();
            if(zh.health==0){
				allScore +=10;
				scoreText.text ="score : "+allScore;
                    saveScore();
			}
          }
	}
    public void saveScore()
    {
        PlayerPrefs.SetInt("score", allScore);
    }
    public int loadScore()
    {
       return  finalScore = PlayerPrefs.GetInt("score");
    }
}

