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
    
    // HaddiScript haddi;

    Dictionary < string, string > boneHints = new Dictionary < string, string > (){
        {"Pelvis", "Basin-shaped complex of bones that connects the trunk and the legs"},
        {"Ulna_Right","A long bone found in the forearm that stretches from the elbow to the smallest finger"},
        {"Ulna_Left","A long bone found in the forearm that stretches from the elbow to the smallest finger"},
        {"Skull","Bones that surround and protect the brain"},
        {"Tibia_Left","Bone which connects the knee with the ankle bones"},
        {"Tibia_Right","Bone which connects the knee with the ankle bones"},
        {"Patella_Left","Sits in front of the knee joint and protects the joint from damage"},
        {"Patella_Right","Sits in front of the knee joint and protects the joint from damage"},
        {"Scapula_Left","A large triangular-shaped bone that suppoprts shoulder movement"},
        {"Scapula_Right","A large triangular-shaped bone that suppoprts shoulder movement"},
        {"Femur_Left","Thigh Bone which is longest, heaviest, and strongest bone in the human body"},
        {"Femur_Right","Thigh Bone which is longest, heaviest, and strongest bone in the human body"},
        {"Clavical_Left","Long, thin, slightly curved bone that connects your arm to your body"},
        {"Clavical_Right","Long, thin, slightly curved bone that connects your arm to your body"},
        {"Fingers_Right","Small bones that connect the hand to the wrist"},
        {"Fingers_Left","Small bones that connect the hand to the wrist"},
        {"Humerous_Left","The bone in your upper arm that's located between your elbow and your shoulder"},
        {"Humerous_Right","The bone in your upper arm that's located between your elbow and your shoulder"},
        {"Radius_Left","The outer of the two bones of the forearm"},
        {"Radius_Right","The outer of the two bones of the forearm"},
        {"Vertebrate_Column","Known as Backbone or Spine"},
        {"Rib_Center","Partially T-shaped vertical bone that forms the anterior portion of the chest wall centrally"},
        {"RibCage","Surrounds the lungs and the heart, serving as an important means of bony protection for these vital organs"},
        {"Foot_Left","Human foot consists of 26 bones that connect the foot to the leg"},
        {"Foot_Right","Human foot consists of 26 bones that connect the foot to the leg"}
    };


    [SerializeField]
    Transform myParent;
    [SerializeField]
    bones thisBone;
    bool choose=true,drop=false;
    SceneBonePosManager bonePosManager;
    Vector3 initialPosition;
    void Start()
    {
        isFixed=false;
        initialPosition=transform.position;
        bonePosManager=FindObjectOfType<SceneBonePosManager>().GetComponent<SceneBonePosManager>();
        // haddi=FindObjectOfType<HaddiScript>().GetComponent<HaddiScript>();
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
            Vector3 finalPos=bonePosManager.GetBonePos(thisBone+"Point");
            // Debug.Log(Vector3.Distance(transform.position,finalPos));
            if(Vector3.Distance(transform.position,finalPos)<0.5){
                myParent.position=finalPos;
                bonePosManager.checkIfGameComplete();
                
                isFixed=true;
            }else{
                myParent.position=initialPosition;
                HaddiScript.instance.values.Add(boneHints[thisBone.ToString()]);
            }
        }
}
}

