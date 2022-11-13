using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigate : MonoBehaviour
{
    // Start is called before the first frame update
    public void Level1(){
        SceneManager.LoadScene(1);
    }
    public void Level2(){
        SceneManager.LoadScene(2);
    }
    public void Level3(){
        SceneManager.LoadScene(3);
    }
    public void BackHome(){
        SceneManager.LoadScene(0);
    }
    public void Quit(){
        SceneManager.LoadScene(4);
    }
    public void QuitGame(){
        Application.Quit();
    }
     public void Settings(){
        SceneManager.LoadScene(5);
    }
}
