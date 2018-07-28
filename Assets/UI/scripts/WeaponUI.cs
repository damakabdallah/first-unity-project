using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUI : MonoBehaviour {
	public GameObject image;
	void OnTriggerStay(Collider other)
	{
		image.SetActive(true);
		transform.LookAt(GameObject.Find("character").transform);
	}
	 void OnTriggerExit(Collider other)
	{
		image.SetActive(false);
	}
}
