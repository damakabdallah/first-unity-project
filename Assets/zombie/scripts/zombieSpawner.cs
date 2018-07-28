using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieSpawner : MonoBehaviour {
    public AudioSource AS;
    public int zombieNumber=0;
    float startTime=5f;
    float endTime=10f;
    public GameObject zombie;
    score score;
	  public Transform[] zombieSpawn;
    void Start ()
    {
        StartCoroutine(StartSpawning());
        score = GameObject.FindGameObjectWithTag("Player").GetComponent<score>();
    }
    void  Update()
    {
        if(zombieNumber>0 && AS.isPlaying==false)
         AS.Play();
        if(zombieNumber==0)
         AS.Stop();
    }
	IEnumerator StartSpawning(){
        yield return new WaitForSeconds(Random.Range(startTime,endTime));
        if(score.allScore%100==0){
            if(startTime>1)
                startTime--;
            if(endTime>1)
                endTime--;
        }
         Instantiate(zombie,zombieSpawn[Random.Range(0,zombieSpawn.Length)].position,zombie.transform.rotation);
         zombieNumber++; 
         StartCoroutine(StartSpawning());
    }

}
