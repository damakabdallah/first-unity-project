using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieAttack : MonoBehaviour {
    CharacterHealth CHH;
    public float timeAttack=0;
    zombieHealth zh;
	// Use this for initialization
	void Start () {
        CHH = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterHealth>();
        zh = GetComponent<zombieHealth>(); 
    }
    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag=="Player"){
            if (timeAttack <100 && zh.health>0)
            {
                timeAttack +=1;
                
            }
            else timeAttack=0;
            if(timeAttack == 90 && zh.health > 0)
            {
                CHH.health -= 10f;
            }
        }
    }

}
