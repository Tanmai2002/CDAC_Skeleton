using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneBonePosManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject Holder;
    public static int boneCorrectCount=0;
    Dictionary<string,Transform> bonePositions;
    void Start()
    {
            boneCorrectCount=0;
        bonePositions=new Dictionary<string, Transform>();
        foreach(Transform t in Holder.GetComponentsInChildren<Transform>()){
            if(t.gameObject.name.ToString()=="Positioner")
                continue;
            Debug.Log(t.gameObject.name.ToString());
            bonePositions.Add(t.gameObject.name.ToString(),t);
            // FindObjectOfType<AudioManager>().Play(Sounds[SoundIn]].name);
        }
        Debug.Log(bonePositions.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Vector3 GetBonePos(string t){
        Debug.Log("Bone :"+bonePositions[t]);
        return bonePositions[t].position;
    }

    public void checkIfGameComplete(){
        boneCorrectCount+=1;
        Debug.Log(boneCorrectCount);
        if(boneCorrectCount==bonePositions.Count){
            GameManager.instance.GameComplete();
            boneCorrectCount=0;
        }
    }
}
