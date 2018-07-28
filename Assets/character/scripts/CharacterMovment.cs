using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovment : MonoBehaviour {

    //variables
    public Animator animCtrl;
    float test;
    float x;
    float y;
    public AudioSource walk;
	// start function
	void Start () {
        animCtrl = GetComponent<Animator>();
	}
	
	// update function
	void Update () {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        walkSound();
        Move(x,y);
        Crouch();

    }


    void Move(float x, float y)
        {
            if (Input.GetKey(KeyCode.LeftShift) && y >= 0)
            {
                animCtrl.SetFloat("x", x * 2);
                animCtrl.SetFloat("y", y * 2);
            }
            else
            {
                animCtrl.SetFloat("x", x);
                animCtrl.SetFloat("y", y);
            }
        }
    void Crouch()
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                animCtrl.SetBool("Crouch", true);
            }
            else
                animCtrl.SetBool("Crouch", false);
        }
   void walkSound(){
        if(x!=0||y!=0)
            walk.Play();
        else
            walk.Stop();
   }
}


