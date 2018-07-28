using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour {
    public float magazine = 5;
    public float allMagazine = 5;
    public Text MagazineText;
    public float ammo = 50;
    public float ammo1shot = 5;
    public float a = 50;
    public float b = 5;
    CharacterWeapons CHW;
    public Text AmmoText;
    // Use this for initialization
    void Awake()
    {
        CHW = GameObject.Find("character").GetComponent<CharacterWeapons>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CHW.weapON.tag == "Weapon")
        {
            AmmoText.text = CHW.Ammo.ammo.ToString() + "/" + a.ToString();
            MagazineText.text = CHW.Ammo.magazine.ToString() + "/" + allMagazine.ToString();
            // if(magazine<=1)
            //     MagazineText.color=Color.red;
            // else
            //     MagazineText.color=Color.white;
        }
        if (CHW.weapON.tag == "weap 1 shot")
        {
            AmmoText.text = CHW.Ammo.ammo1shot.ToString() + "/" + b.ToString();
            MagazineText.text = CHW.Ammo.magazine.ToString() + "/" + allMagazine.ToString();
            // if(magazine<=1)
            //     MagazineText.color=Color.red;
            // else
            //     MagazineText.color=Color.white;
        }

    }
}
