using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMoreAmmo : MonoBehaviour {
    CharacterWeapons CHW;
    public AudioSource AS;
    void Awake()
    {
        CHW = GameObject.Find("character").GetComponent<CharacterWeapons>();
    }
    void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag == "Player" && CHW.Ammo.magazine==0 && CHW.Ammo.ammo==0)
         {
             CHW.Ammo.ammo = CHW.Ammo.a;
             AS.Play();
         }
         else
         if(other.gameObject.tag == "Player" && CHW.Ammo.magazine==0 &&CHW.Ammo.ammo1shot==0)
         {
             CHW.Ammo.ammo1shot=CHW.Ammo.b;
             AS.Play();
         }
         else
        if (other.gameObject.tag == "Player" && CHW.Ammo.magazine < CHW.Ammo.allMagazine)
        {
            CHW.Ammo.magazine += 1f;
            AS.Play();
        }
        else 
        if (other.gameObject.tag == "Player"&& CHW.weapON.tag== "Weapon" && CHW.Ammo.ammo < CHW.Ammo.a)
        {
            CHW.Ammo.ammo = CHW.Ammo.a;
            AS.Play();
        }
        else
        if (other.gameObject.tag == "Player" && CHW.weapON.tag == "weap 1 shot" && CHW.Ammo.ammo1shot < CHW.Ammo.b)
        {
            CHW.Ammo.ammo1shot = CHW.Ammo.b;
            AS.Play();
        }

    }
}
