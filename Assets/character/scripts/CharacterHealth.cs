using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterHealth : MonoBehaviour {
    public float health=100;
    public Image healthBar;
    public NewGame ng;
	// Update is called once per frame
	void Update () {
        healthBar.fillAmount = health / 100f;
        if (health <= 0)
        {
            
            SceneManager.LoadScene("die menu");
        }
        
	}
}
