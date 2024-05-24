using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class try_again : MonoBehaviour
{
   public void onclick(){
       SceneManager.LoadScene(1);
    }
    public void exit(){
        Application.Quit();
    }
}
