using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Settings : MonoBehaviour
{
    [SerializeField] GameObject popup;

    public void Popup()
    {
        popup.SetActive(true);
        FindObjectOfType<Timer>().StopTimer();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
