using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level0sound : MonoBehaviour {

    public generalSound gs;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        AudioListener.volume = gs.volume;
        Debug.Log(AudioListener.volume);
	}
}
