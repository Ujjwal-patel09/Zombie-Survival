using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{
  public Slider slider;
  public Gradient gradient;
  public Image bar;
  
  public void maxhealth(int health){
    slider.maxValue = health;
    slider.value = health;

     bar.color = gradient.Evaluate(1f);
  }
  public void sethealth(int health){
    slider.value = health;
     bar.color = gradient.Evaluate(slider.normalizedValue);
  }
}
