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
    public void BackHome(){
        SceneManager.LoadScene(0);
    }
}
