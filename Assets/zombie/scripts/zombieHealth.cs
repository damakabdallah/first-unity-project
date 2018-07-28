using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zombieHealth : MonoBehaviour {
    zombieSpawner zs;
    public float health = 100;
    public Image healthBar;
    Animator anim;
    public AudioSource AS;
	// Use this for initialization
	void Awake () {
        anim = GetComponent<Animator>();
        zs=GameObject.FindGameObjectWithTag("zombieSpawner").GetComponent<zombieSpawner>();
	}
	
	// Update is called once per frame
	void Update () {
        healthBar.fillAmount = health / 100f;
        if (health <= 0)
        {
            if(AS.isPlaying==false){
            AS.Play();
            }
            StartCoroutine("wait");
        }
        if(health==0)
            zs.zombieNumber--;
    }
    IEnumerator wait()
    {
        anim.SetBool("dead", true);
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }
}
