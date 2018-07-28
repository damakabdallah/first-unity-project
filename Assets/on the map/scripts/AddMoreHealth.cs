using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMoreHealth : MonoBehaviour {
    CharacterHealth AddHealth;
    public AudioSource AS;
	// Use this for initialization
	void Start () {
        AddHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterHealth>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && AddHealth.health < 100)
        {
            AS.Play();
            AddHealth.health += 30;
        }
        if (AddHealth.health > 100)
            AddHealth.health = 100;
    }
}
