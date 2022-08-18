using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HaddiScript : MonoBehaviour
{
    [SerializeField]
    MeshRenderer renderer;

    [SerializeField]
    TextMeshPro text;
    [SerializeField]
    public List<string> values;

    [SerializeField]
    GameObject textfield;
    [SerializeField]
    SpriteRenderer spriteRenderer;

    bool canGoNext;
    Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator=GetComponent<Animator>();
        canGoNext=true;
        renderer.sortingOrder=12;
        text.SetText("Hello Tanmai");
        animator.SetInteger("dialogCount",values.Count);
    }

   void resetCanGo(){
    canGoNext=true;
   }
   void setFalseTextExit(){
            animator.SetBool("textExit",false);
            
                text.SetText(values[0]);
   }
   void MakeItZero(){
    spriteRenderer.enabled=false;
            textfield.SetActive(false);

   }
    void FixedUpdate()
    {
        
        animator.SetInteger("dialogCount",values.Count);
        
        if(values.Count<=0){
            Invoke("MakeItZero",0.5f);

            
            return;
        }
        if(values.Count>0 && spriteRenderer.enabled==false){

            text.SetText(values[0]);
            spriteRenderer.enabled=true;
            textfield.SetActive(true);
            canGoNext=false;
            
                Invoke("resetCanGo",1);
        }

        if(canGoNext && Input.GetMouseButtonDown(0)){
            values.RemoveAt(0);
            animator.SetBool("textExit",true);
            if(values.Count<=0){
                
            Invoke("MakeItZero",0.5f);
                
            animator.SetBool("textExit",false);

                return;
            }else{
                
                Invoke("setFalseTextExit",0.2f);
                canGoNext=false;
                Invoke("resetCanGo",1);
                
            }

        }

    }

}
