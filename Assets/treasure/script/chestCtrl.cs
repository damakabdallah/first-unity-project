using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestCtrl : MonoBehaviour {
	Animator chestAnim;

	// Use this for initialization
	void Start () {
		chestAnim=GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerStay(Collider other)
	{
		if(other.gameObject.tag=="Player"){
			chestAnim.SetBool("open",true);
			chestAnim.SetBool("close",false);
		}

	}
	 void OnTriggerExit(Collider other)
	{
		if(other.gameObject.tag=="Player"){
			chestAnim.SetBool("open",false);
			chestAnim.SetBool("close",true);
		}
	}
}
