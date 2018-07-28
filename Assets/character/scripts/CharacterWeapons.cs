using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterWeapons : MonoBehaviour {
    public Vector3 WeapPos = new Vector3(-0.057f, 0.194f,0.041f);
    public Vector3 weapRot = new Vector3(174.401f, 2.815994f, 113.648f);
    public GameObject weapON,weapOFF,parentON,parentOFF,enemy;
    public Ammo Ammo;
    public ParticleSystem PS;
    public zombieHealth zh;
    public Text weapFocus;
    public AudioSource[] sounds;
    AudioSource weaponSound;
 	// Use this for initialization
	void Awake () {
        sounds = GetComponents<AudioSource>();
        weapON.transform.localPosition = WeapPos;
        weapON.transform.localEulerAngles = weapRot;
        Ammo = weapON.GetComponent<Ammo>();
        Cursor.lockState = CursorLockMode.Locked;
    }


    // Update is called once per frame
    void Update()
    { 
        
        Ammo = weapON.GetComponent<Ammo>();
        if (Input.GetMouseButton(0) && Input.GetMouseButton(1) && weapON.tag == "Weapon" && Ammo.ammo != 0)
            fire();
        if (Input.GetMouseButtonDown(0) && Input.GetMouseButton(1) && weapON.tag == "weap 1 shot" && Ammo.ammo1shot!=0)
            fire1shot();
        if(weapON.tag == "Weapon"&&Input.GetMouseButtonUp(0)||Ammo.ammo==0)
            weaponSound.Stop();
        getWeapon();
    }
    void getWeapon(){
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 1.5f)&&(hit.transform.tag== "Weapon"|| hit.transform.tag == "weap 1 shot")&&hit.transform.gameObject!=weapON){
                 weapFocus.text = "press E to get " + hit.transform.gameObject.name;
            if (Input.GetKeyUp(KeyCode.E))
                 withWeapon(hit.transform.gameObject);
        }
        else
         weapFocus.text = "";
    }
   
    void OnTriggerExit(Collider other)
    {
        if ((other.transform.name != weapON.transform.name) && (other.transform.tag == "Weapon" || other.transform.tag == "weap 1 shot"))

            weapFocus.text = "";
    }
    void withWeapon(GameObject other)
    {
        //old weapon
        weapOFF = weapON;
        weapOFF.transform.SetParent(parentOFF.transform);
        weapOFF.transform.position = other.transform.position;
        weapOFF.transform.localRotation = new Quaternion(0, 0, 0, 0);
        //new weapon
        weapON = other;
        weapON.transform.SetParent(parentON.transform);
        weapON.transform.localPosition = WeapPos;
        weapON.transform.localEulerAngles = weapRot;
    }
    void fire()
    {
         weaponSound = sounds[1];
        RaycastHit hit;
        PS = weapON.GetComponentInChildren<ParticleSystem>();
        if (Ammo.ammo > 0)
        {
            PS.Play();
            if(weaponSound.isPlaying==false)
            weaponSound.Play();
            Ammo.ammo--;

        }
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 100f)&&Ammo.ammo!=0)
          if(hit.transform.tag=="enemy")
          {
            zh =hit.transform.GetComponent<zombieHealth>();
            zh.health-=10;
          }
           StartCoroutine("Reload");
        

    }
    void fire1shot()
    {
        weaponSound=sounds[2];
        RaycastHit hit;
        PS = weapON.GetComponentInChildren<ParticleSystem>();
        if (Ammo.ammo1shot > 0)
        {
            PS.Play();
            Ammo.ammo1shot--;
            weaponSound.Play();
        }
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 100f)&&Ammo.ammo!=0)
            if (hit.transform.tag == "enemy")
            {
                zh =hit.transform.GetComponent<zombieHealth>();
                zh.health -= 34;
            }
        StartCoroutine("Reload1Weapon");
    }

    IEnumerator  Reload()
    {
        
        if (Ammo.ammo == 0 && Ammo.magazine >= 1)
        {
            yield return new WaitForSeconds(1);
            weaponSound=sounds[3];
            weaponSound.Play();
            Ammo.ammo = Ammo.a;
            Ammo.magazine--;
        }
    }
    IEnumerator Reload1Weapon()
    {
        if (Ammo.ammo1shot == 0 && Ammo.magazine >= 1)
        {
            weaponSound=sounds[3];
            weaponSound.Play();
            yield return new WaitForSeconds(1);
            Ammo.ammo1shot = Ammo.b;
            Ammo.magazine--;
        }
    }
}
