using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using Unity.Mathematics;
using UnityEditor.Rendering;
using UnityEngine;

public class Machine_Gun : MonoBehaviour
{
    public float roatate_speed = 30;
    public GameObject bullet;
    public GameObject medic;
   
    public Transform bulletspawn;
    float nextfire;
    public float fire_rate;
    public AudioSource gun_sound; 
   

    // Update is called once per frame
    void Update()
    {
       if(Time.time > nextfire){

         nextfire = Time.time + fire_rate;
         Instantiate(bullet,bulletspawn.transform.position,bulletspawn.transform.rotation);
         gun_sound.Play();
                   
       }
    }
    private void FixedUpdate() {
        
        transform.Rotate(0,0,roatate_speed*Time.fixedDeltaTime);
    }
    
   private void OnTriggerEnter2D(Collider2D col) {
      
      if(col.gameObject.tag == "rotate_point"){
         roatate_speed = 30;
      }
      if(col.gameObject.tag == "rotate_point1"){
         roatate_speed = -30;
      }

   }
   private void OnDestroy() {
      Instantiate(medic,transform.position,transform.rotation);
   }
}
