using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class zombiemove : MonoBehaviour {
    zombieSpawner zs;
    GameObject player;
    NavMeshAgent nma;
Animator zombieAnim;
zombieHealth ZH;
// Use this for initialization
void Start () {
    ZH = GetComponent<zombieHealth>();
    zombieAnim = GetComponent<Animator>();
    nma = GetComponent<NavMeshAgent>();
    player = GameObject.Find("character");
    
}

// Update is called once per frame
void Update () {
    if (ZH.health > 0)
    {
        nma.SetDestination(player.transform.position);
        
    }
    else
    {
        nma.isStopped=true;
    }
}
void OnTriggerStay(Collider other)
{
    if (other.gameObject.tag == "Player")
    {
        zombieAnim.SetBool("player", true);
        
    }
}
void OnTriggerExit(Collider collider)
{
        if (collider.gameObject.tag == "Player")
    {
    zombieAnim.SetBool("player", false);
    }
}

}
