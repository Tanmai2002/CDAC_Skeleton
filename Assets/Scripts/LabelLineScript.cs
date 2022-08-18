using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabelLineScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Transform Pointer;

    [SerializeField]
    LineRenderer line;
  
    void Start()
    {
        float x2=Pointer.position.x;
        float y2=Pointer.position.y;
        float x1=this.transform.position.x+((x2>this.transform.position.x)?1.5f:-1.5f);
        float y1=this.transform.position.y;
        
        line.SetPosition(0,new Vector3(x1,y1,0));
        // line.SetPosition(1,new Vector3((x1+x2)/2,y1,0));
        
        // line.SetPosition(2,new Vector3((x1+x2)/2,y2,0));
        
        line.SetPosition(1,new Vector3(x2,y2,0));
        line.sortingOrder=-3;
        line.startColor=new Color(0,0,0);
        line.endColor=new Color(0,0,0);
    
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
