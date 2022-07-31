using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneDragScript : MonoBehaviour
{
    public enum bones{
        Skull,RibCage,Femur_Left,Femur_Right,Clavical_Right,Clavical_Left,Fingers_Right, Fingers_Left,Humerous_Left, Humerous_Right,Ulna_Left, Ulna_Right, Rib_Center,Foot_Left,Foot_Right,Pelvis, Vertebrate_Column,Radius_Left, Radius_Right, Tibia_Left, Tibia_Right, Scapula_Left, Scapula_Right,Patella_Left, Patella_Right
        }
    bool isFixed;
    [SerializeField]
    bool DebugMode=false;
    
    HaddiScript haddi;





    [SerializeField]
    Transform myParent;
    [SerializeField]
    bones thisBone;
    bool choose=true,drop=false;
    Vector3 initialPosition;
    void Start()
    {
        isFixed=false;
        initialPosition=transform.position;
        haddi=FindObjectOfType<HaddiScript>().GetComponent<HaddiScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!choose ){
                 myParent.position=Camera.main.ScreenToWorldPoint(Input.mousePosition+new Vector3(0,0,10));
       
        }
       

        
    }
    void OnMouseDown(){
    Debug.Log("Sprite Clicked");
    if(isFixed && !DebugMode){
        return;
    }
     if(choose){
            choose=false;
            drop=true;

        }else if(drop){
            choose=true;
            drop=false;
            Debug.Log(thisBone+"Point");
            Vector3 finalPos=FindObjectOfType<GameManager>().GetBonePos(thisBone+"Point");
            Debug.Log(Vector3.Distance(transform.position,finalPos));
            if(Vector3.Distance(transform.position,finalPos)<0.5){
                myParent.position=finalPos;
                isFixed=true;
            }else{
                myParent.position=initialPosition;
                haddi.values.Add("Please Try again");
            }
        }
}
}

