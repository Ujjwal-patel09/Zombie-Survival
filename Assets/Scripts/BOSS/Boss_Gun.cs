using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Boss_Gun : MonoBehaviour
{
     public float speed = 1f;
     public GameObject bullet;
     public GameObject flash;
     public GameObject[] flash_destroy;
     public Transform bullet_spawn;
     public float fire_rate;
     float nextfire ;
     public Animator anim;
     

     // health veriables//
     public Boss_health_bar boss_Health_Bar;
     public int boss_max_hp = 100;
     int boss_current_hp;
     public int boss_damage;
     public Canvas Boss_canvas;

     //boss transition variables//
     public GameObject shild;
     public Transform shild_trans_point;
     bool isshild = false;
     bool isshild_LV2 = false;

     public GameObject[] circles;
     public GameObject[] machine_Guns;

     public GameObject transformer;
     public Transform[] transformer_point_LV1;
     public Transform[] transformer_point_LV2;
     bool is_tranformer = false;
     bool is_tranformer_LV2 = false;

    void Start()
    {
        boss_current_hp = boss_max_hp;
        boss_Health_Bar.max_Boss_health(boss_max_hp);
    }

    void Update()
    {
       // health is zero//
       if(boss_current_hp <= 0){
        Destroy(this.gameObject);
        SceneManager.LoadScene(3);
       }

       //health is 30//
       if(boss_current_hp == 40){
         
         for (int i = 0; i <circles.Length; i++)
         {
           circles[i].SetActive(true);
         }
        
         if(isshild_LV2 == false){//spawn shild LV2//
            Instantiate(shild,shild_trans_point.position,shild_trans_point.rotation);
            isshild_LV2 = true;
         }

         if(is_tranformer_LV2 == false){// spawn transformer LV2//
           for (int i = 0; i < transformer_point_LV2.Length; i++)
           {
             Instantiate(transformer,transformer_point_LV2[i].position,transformer_point_LV2[i].rotation);     
           }
           is_tranformer_LV2 = true;
         }

       }

       //health is 70//
       if(boss_current_hp ==70){

        if(isshild == false){// spawn shild //
           Instantiate(shild,shild_trans_point.position,shild_trans_point.rotation);
           isshild = true;
        }

        for (int i = 0; i < machine_Guns.Length; i++)//Active Machine_GUN//
        {
          machine_Guns[i].SetActive(true);
        }

        if(is_tranformer == false){// spawn transformer//
          for (int i = 0; i < transformer_point_LV1.Length; i++)
          {
             Instantiate(transformer,transformer_point_LV1[i].position,transformer_point_LV1[i].rotation);     
          }
          is_tranformer = true;
        }

       }

      // bullet and flash shooting and destroy//

    }
    private void FixedUpdate() {
        
        if(Time.time > nextfire){

            nextfire = Time.time + fire_rate;
           
              anim.SetBool("isshoot",true);
              Instantiate(bullet,bullet_spawn.transform.position,bullet_spawn.transform.rotation);
              Instantiate(flash,bullet_spawn.transform.position,bullet_spawn.transform.rotation);
            
        }
        flash_destroy= GameObject.FindGameObjectsWithTag("Boss_flash");

              for (int e = 0; e < flash_destroy.Length; e++)
              {
                Destroy(flash_destroy[e],0.01f);
              }
              
        transform.Rotate(0,0,speed*Time.fixedDeltaTime);
        
    }
    
    // health and damage from player_bullet//
    private void OnTriggerEnter2D(Collider2D other) {
      
      if(other.gameObject.tag == "bullet"){
        Destroy(other.gameObject);
        Boss_canvas.enabled = true;
        boss_current_hp -= boss_damage;
        boss_Health_Bar.set_Boss_health(boss_current_hp);
      }
    }
    
  

     // spawn transformer LV2//
    IEnumerator transformer_spawn_LV2(){

      yield return new WaitForSeconds(0.01f);
      for (int i = 0; i < transformer_point_LV2.Length; i++)
      {
      Instantiate(transformer,transformer_point_LV2[i].position,transformer_point_LV2[i].rotation);     
      }
      is_tranformer_LV2 = true;
    }
}
