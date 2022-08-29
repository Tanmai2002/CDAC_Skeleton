using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class BonePlacement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject []bone;
    public Transform []boneHolder;
    [SerializeField]
    private GameObject []boneClone;
    public GameObject silouette;
    private GameObject current;
    private bool state = true;

    public QuizManager quizM;

    public Text currentBoneName;
    private string []boneName = {"Skull","RibCage","Femur","Femur","Clavical","Clavical","Finger","Finger","Foot","Foot","Humerus","Humerus","Sternum","Ulna","Ulna","Vertebrate","Pelvis","Tibia","Tibia","Scapula","Scapula","Patella","Patella"};
    

    void Start()
    {
        boneHolder = silouette.GetComponentsInChildren<Transform>();
        
        boneClone = new GameObject[bone.Length];
        for(int i=0;i<bone.Length;i++){
            boneClone[i] = Instantiate(bone[i],boneHolder[i+1].position,boneHolder[i+1].rotation);
            BoneDragScript bs = boneClone[i].GetComponentInChildren<BoneDragScript>();
            bs.enabled = false;
        }
    }

    private static readonly Random getrandom = new Random();

    public static int GetRandomNumber(int min, int max){
        lock(getrandom) // synchronize
        {
        return getrandom.Next(min, max);
        }
    }

    public void next(){
         current.GetComponentInChildren<SpriteRenderer>().color = Color.white;
         current=null;
        state = true;
    }

    void Update(){
        if(state){
            int r = GetRandomNumber(0,boneClone.Length);
            current = boneClone[r];
            current.GetComponentInChildren<SpriteRenderer>().color = Color.red;
            currentBoneName.text = boneName[r];
            quizM.question.answer = boneName[r];
            quizM.SetQuestion();
            state=false;
        }
    } 
}
