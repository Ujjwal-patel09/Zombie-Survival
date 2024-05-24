using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_health_bar : MonoBehaviour
{
  public Slider slider;
  
  
  public void max_Boss_health(int health){
    slider.maxValue = health;
    slider.value = health;

     
  }
  public void set_Boss_health(int health){

    slider.value = health;
    
  }
}
