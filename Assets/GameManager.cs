using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject Holder;
    Dictionary<string,Transform> bonePositions;
    void Start()
    {
        bonePositions=new Dictionary<string, Transform>();
        foreach(Transform t in Holder.GetComponentsInChildren<Transform>()){
            Debug.Log(t.gameObject.name.ToString().Equals("SkullPoint"));
            bonePositions.Add(t.gameObject.name.ToString(),t);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Vector3 GetBonePos(string t){
        Debug.Log("Bone :"+bonePositions[t]);
        return bonePositions[t].position;
    }
}
