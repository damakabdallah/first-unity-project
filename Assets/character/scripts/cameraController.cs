using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour {
    public Transform playerCam, character, target,AimParent,normalParent,centerPoint;
    public GameObject WhiteCrossHair;
    public GameObject RedCrossHair;
    Vector3 dest;
    private float mouseX, mouseY;
     float mouseYPosition = 1f;
    
     float zoom=-3;

     float rotationSpeed = 5f;
    
    Animator anim;
    // Use this for initialization
    void Start()
    {
        anim = character.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        centerPoint.position=gameObject.transform.position+new Vector3(0,1.57f,0);
        
        //getting axis
        mouseX += Input.GetAxis("Mouse X");
        mouseY += Input.GetAxis("Mouse Y");

        dest=centerPoint.position+centerPoint.forward*-1+Vector3.up*mouseY;
        RaycastHit hit;
        if(Physics.Linecast(playerCam.position,character.position,out hit)){
            if(hit.collider.CompareTag("terrain"))
                playerCam.localPosition=hit.point;
        }
        // function to rotate the camera
        RotCam();
        //make the camera(his parent is the target) behind the caracter
        target.position = new Vector3(character.position.x, character.position.y + mouseYPosition, character.position.z);
        //make the character move on local camera direction
        SetCamChar();
        

    }
    void RotCam()
    {
            //limit camera rotation
            if(Input.GetMouseButton(1))
                 mouseY = Mathf.Clamp(mouseY, -70f, 70f);
            else
                 mouseY = Mathf.Clamp(mouseY, -1f, 60f);
            //camera rotation
            target.localRotation = Quaternion.Euler(mouseY, mouseX, 0);
        
    }
    void SetCamChar()
    {
        playerCam.transform.localPosition = new Vector3(0, 0, zoom);
        if (Input.GetMouseButton(1))
        {
            Quaternion turnAngle = Quaternion.Euler(0, target.eulerAngles.y, 0);
            character.rotation = Quaternion.Slerp(character.rotation, turnAngle, Time.deltaTime * rotationSpeed);
            Aim();
        }
        else
        {
            WhiteCrossHair.SetActive(false);
            RedCrossHair.SetActive(false);
            anim.SetBool("in aim", false);
        }
        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            //get the target rotation on y axis (or  target  angle on y axis)
            Quaternion turnAngle = Quaternion.Euler(0, target.eulerAngles.y, 0);
            // Quaternion.Slerp(sarting rotation,ending rotation ,speed)
            character.rotation = Quaternion.Slerp(character.rotation, turnAngle, Time.deltaTime * rotationSpeed);

        }
    }
    void Aim()
    {
        anim.SetBool("in aim", true);
        anim.SetFloat("aim Angle",mouseY+30);
        playerCam.localPosition = new Vector3(0.81f,0.5f,-1.1f);
        target.localRotation = Quaternion.Euler(-mouseY, mouseX, 0);
        RaycastHit hit;
        if(Physics.Raycast(transform.position,transform.forward,out hit,100f)&&hit.transform.gameObject.tag=="enemy")
        {
            RedCrossHair.SetActive(true);
            WhiteCrossHair.SetActive(false);
        }
        else
        {
            WhiteCrossHair.SetActive(true);
            RedCrossHair.SetActive(false);
        }
       
    }
}

