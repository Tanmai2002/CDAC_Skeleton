using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextAnimator : MonoBehaviour
{
    [SerializeField]
    float delayTime;
    [SerializeField]
   TextMeshPro mytext;
   [SerializeField]
    string textToDisplay;
    [SerializeField]
    bool onLetter;
    string currText="";
    [SerializeField]
    string[] terms;
    char[] terms1;
    bool next=true;
    [SerializeField]
    int fontSize=10;
    [SerializeField]
    TMP_FontAsset f;
    public bool completed=false;
    int i=0;

    // Start is called before the first frame update
    void Start()
    {
        mytext.SetText("");
        mytext.font=f;
    
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

        
        mytext.fontSize=fontSize;
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
    mytext.SetText(currText);
        i++;
        next=false;
        Invoke("addTextNewText",delayTime);
}
        
    }

    public void addTextToAnimate(string text){
        textToDisplay=text;
        
        currText="";
        mytext.SetText("");
    
        terms=textToDisplay.Split(" ");
        if(onLetter){
            terms1=textToDisplay.ToCharArray();
        }
        i=0;
        next=true;
        completed=false;
        
    }

    
}
