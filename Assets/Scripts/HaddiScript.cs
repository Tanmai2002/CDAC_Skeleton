using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HaddiScript : MonoBehaviour
{
    [SerializeField]
    new MeshRenderer renderer;
    public static HaddiScript instance;
    TextAnimator textanim;

    // [SerializeField]
    // TextMeshPro text;
    [SerializeField]
    public List<string> values;

    [SerializeField]
    GameObject textfield;
    [SerializeField]
    SpriteRenderer spriteRenderer;

    

    bool canGoNext;
    bool isFirstTime = true;
    Animator animator;


    
    // Start is called before the first frame update
    void Start()
    {
        instance=this;
        textanim=GetComponent<TextAnimator>();
        animator=GetComponent<Animator>();
        canGoNext=true;
    
        renderer.sortingOrder=12;
        // text.SetText("Hello Tanmai");
        animator.SetInteger("dialogCount",values.Count);
    }

   void setFalseTextExit(){
            animator.SetBool("textExit",false);
            textanim.addTextToAnimate(values[0]);

            
                // text.SetText(values[0]);
   }
   void MakeItZero(){
    spriteRenderer.enabled=false;
            textfield.SetActive(false);

   }
    void Update()
    {
        if(textanim.completed){
            canGoNext=true;
        }
        
        animator.SetInteger("dialogCount",values.Count);
        
        if(values.Count<=0){
            Invoke("MakeItZero",0.5f);
            AudioManager.instance.stopForeground();
            if(isFirstTime){
                GameManager.instance.timer.StartTimer();
                isFirstTime=false;
            }
            
            return;
        }
        if(values.Count>0 && spriteRenderer.enabled==false){
            if(AudioManager.instance!=null){
                AudioManager.instance.playForeground("haddi1");
            }
            textanim.addTextToAnimate(values[0]);
            // text.SetText(values[0]);
            spriteRenderer.enabled=true;
            textfield.SetActive(true);
            canGoNext=false;
            
                // Invoke("resetCanGo",1);
        }

        if(canGoNext && Input.GetMouseButtonDown(0)){
            values.RemoveAt(0);
            animator.SetBool("textExit",true);
            if(values.Count<=0){
            if(isFirstTime){
                GameManager.instance.timer.StartTimer();
                isFirstTime=false;
            }
                
            Invoke("MakeItZero",0.5f);
                
            animator.SetBool("textExit",false);

                return;
            }else{
                
                Invoke("setFalseTextExit",0.2f);
                canGoNext=false;
                // Invoke("resetCanGo",1);
                
            }

        }

    }

}
