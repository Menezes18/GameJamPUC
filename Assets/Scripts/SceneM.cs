using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneM : MonoBehaviour
{
    public string scenename;
    public string ONU = "https://www.instagram.com/seuperfil"; 
    public Button ONUbutton; 

    // Start is called before the first frame update
    public void Start(){
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Load()
    {
        SceneManager.LoadScene(scenename); 
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void OpenURL(string url)
    {
        Application.OpenURL(url);
    }
    
}
