using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public HaddiScript haddi;
    private Scene scene;

    public static GameManager instance;
    
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

    SceneManager.sceneLoaded -= OnSceneLoaded;
    
    // Add the listener to be called when a scene is loaded
    SceneManager.sceneLoaded += OnSceneLoaded;

    DontDestroyOnLoad(gameObject);

    // Store the creating scene as the scene to trigger start
    scene = SceneManager.GetActiveScene();
        
    }
    // Start is called before the first frame update
  
    private void OnDestroy()
{
    // Always clean up your listeners when not needed anymore
    SceneManager.sceneLoaded -= OnSceneLoaded;
    haddi=null;
}

// Listener for sceneLoaded
private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
{
   
    if(scene.buildIndex==0)
    return;
    

    haddi=FindObjectOfType<HaddiScript>().GetComponent<HaddiScript>();
  

    // do your "Start" stuff here
}

    
    public void timerEnded(){
        Debug.Log("Timer Ended");
        haddi.values.Add("Sorry The Timer Has Ended");

    }
    void GoToHomePage(){
        SceneManager.LoadScene(0);
    }
    public void GameComplete(){
        Debug.Log("Timer Ended");
        haddi.values.Add("Congratulations!!! You have Completed the Game");
        Invoke("GoToHomePage",5);
    }


}
