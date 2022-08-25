using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextAnimator : MonoBehaviour
{
    [SerializeField]
    float delayTime;
    [SerializeField]
   TextMeshProUGUI mytext;
   [SerializeField]
    string textToDisplay;
    [SerializeField]
    bool onLetter;
    string currText="";
    [SerializeField]
    string[] terms;
    char[] terms1;
    bool next=true;
    public bool completed=false;
    int i=0;

    // Start is called before the first frame update
    void Start()
    {
        mytext.text="";
    
        terms=textToDisplay.Split(" ");
        if(onLetter){
            terms1=textToDisplay.ToCharArray();
        }
        
    }
    
    void addTextNewText(){
        next=true;

    }

    // Update is called once per frame
    void FixedUpdate()
    {

if(next ){
    if(onLetter){
        if(i>=terms1.Length){

            completed=true;
        return;
        }
        currText+=terms1[i];
    }else{
        if(i>=terms.Length){
            completed=true;
        return;
        }
        currText+=" "+terms[i];
    }
    mytext.text=currText;
        i++;
        next=false;
        Invoke("addTextNewText",delayTime);
}
        
    }

    
}
