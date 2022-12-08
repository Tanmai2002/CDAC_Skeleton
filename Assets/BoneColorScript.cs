using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneColorScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Color boneColor;
    void Start()
    {
        SpriteRenderer[] render=GetComponentsInChildren<SpriteRenderer>();
        foreach(SpriteRenderer r in  render){
            r.color=boneColor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
