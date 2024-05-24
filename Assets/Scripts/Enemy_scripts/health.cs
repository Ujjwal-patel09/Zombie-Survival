using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health : MonoBehaviour
{
   public Slider slider1;
 
   public void maxhealth(int health1){
    slider1.maxValue = health1;
    slider1.value = health1;
   }

   public void sethealth1(int health1){
    slider1.value = health1;
   }
}
