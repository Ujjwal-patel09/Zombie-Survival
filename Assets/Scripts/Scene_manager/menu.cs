using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
   public  void strat1(){
      SceneManager.LoadScene(1);
   }
   public void Exit1(){
      Application.Quit();
   }
}
