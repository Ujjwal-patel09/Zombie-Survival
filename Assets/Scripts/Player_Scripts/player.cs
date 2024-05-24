using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{    
    // For spwan blood object when zomie health is zero//
    public zombie[] zombie;
    public Akm_enemy[] akm_enemy;
    public gun_enemy[] Gun_enemy;
    public GameObject blood;
    public AudioSource blood_splash;
  
     
    // For player movement and rotation with joystick//
    public FixedJoystick joystick;//movement//
    public FixedJoystick joystick1;//rotation// 
    public float speed;
    public Camera cam;
    public shooting shooting;// shooting script//
    public AudioSource footstep;

    //Player health  used in function on line 153 , and used in zombie script also//
    int max_health = 100;
    public int zombie_damage = 10;
    public int Gun_enemy_damage = 7;
    public int AKM_enemy_damage = 4;
    public int Boss_Gun_damage = 20;
    public int machine_Gun_damage = 10;
    public  int current_healthP;
    public  SpriteRenderer playercolor;
    Color red = new Color(1,0.4f,0.4f);
    public healthbar healthbar;
    
   
  
    private Rigidbody2D rb;
    private Vector2 move;
    private Vector2 rotate;
    public bool isakm = false;//for detecting akm is collected or not//
     
    //for collecting Key//
    public bool iskeyred = false;
    public bool iskeygreen = false;
    public bool iskeyyellow = false;
    public bool iskeygrey = false;
    public bool iskeyBlue = false;
    
    private Game_reloader GR;
    public Canvas Boss_canvas;// this is for disable canvas in start of game //
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playercolor = GetComponent<SpriteRenderer>();
        Boss_canvas.enabled = false;

        zombie = null; // null refence expenstion error//
        akm_enemy = null; 
        Gun_enemy = null; 


        //Player health //
        current_healthP = max_health;
        healthbar.maxhealth(max_health);
      
       GR = FindObjectOfType<Game_reloader>();
       transform.position = GR.lastcheck_point;

    }
  
    void Update()
    {
      if(current_healthP <= 0){
        SceneManager.LoadScene(2);
      }
    
      // movement vector for joystick//
      move.x = joystick.Horizontal;
      move.y = joystick.Vertical;
     
      //rotation vector for  joystick//
      rotate.x = joystick1.Horizontal;
      rotate.y = joystick1.Vertical;
      
      //For incresing firerate when akm is collected//
      if(isakm == true){
        shooting.firerate = 0.2f;
      }
      
      Blood_enemy(); // spawn blood when destroy enemies// // for destroy blood prefeb go to player_animation script//
     
    }

    private void FixedUpdate()
    {
      // Movement of player//
         // rb.velocity =  new Vector2(move.x,move.y)*speed*Time.fixedDeltaTime;
         if(joystick.Horizontal >=0.1f || joystick.Horizontal<=-0.1f || joystick.Vertical>=0.1f || joystick.Vertical<=-0.1f){

           transform.position += new Vector3(move.x,move.y,0)*speed*Time.fixedDeltaTime;
           
         }

      //Rotation//
      float xaxis = rotate.x;
      float yaxis = rotate.y;
      float zaxis = Mathf.Atan2(-xaxis,yaxis)*Mathf.Rad2Deg;
          //transform.eulerAngles = new Vector3(0,0,zaxis+90);
      rb.rotation = zaxis+90f;

     
    }   


    // This function is called in zombie script and zombie animation function//
    public void player_health(){

      current_healthP -= zombie_damage;
      playercolor.color = red;
      healthbar.sethealth(current_healthP);


    } 
    private void OnTriggerEnter2D(Collider2D tri) {
      
       //Red key//
      if(tri.gameObject.tag == "redkey"){
      
        Destroy(GameObject.FindWithTag("redkey"));
        iskeyred = true;
      }
      //green key//
      if(tri.gameObject.tag =="greenkey"){
        
        Destroy(GameObject.FindWithTag("greenkey"));
        iskeygreen = true;
      
      }
      //yellow key//
      if(tri.gameObject.tag =="yellowkey"){
         
        Destroy(GameObject.FindWithTag("yellowkey"));
        iskeyyellow = true;

      }
      //grey key//
       if(tri.gameObject.tag =="greykey"){
         
        Destroy(GameObject.FindWithTag("greykey"));
        iskeygrey = true;

      }
      //Blue key//
       if(tri.gameObject.tag =="Bluekey"){
         
        Destroy(GameObject.FindWithTag("Bluekey"));
        iskeyBlue = true;

      }
      //For collecting AKM gun //
      if(tri.gameObject.tag == "AKM"){

        Destroy(GameObject.FindWithTag("AKM"));
        isakm = true;
        shooting.maxbullet = 30;
      }

      //for increse health with medic//
      if(tri.gameObject.tag == "medic_Box"){
         
         Destroy(tri.gameObject);
         current_healthP = max_health;
         healthbar.sethealth(current_healthP);

      }
      
      // damage from gun enemy //
      if(tri.gameObject.tag == "Gun_bullet"){

        current_healthP -= Gun_enemy_damage;
        playercolor.color = red;
        healthbar.sethealth(current_healthP);

      }
      if(tri.gameObject.tag == "AKM_bullet"){

        current_healthP -= AKM_enemy_damage;
        playercolor.color = red;
        healthbar.sethealth(current_healthP);
      }
      if(tri.gameObject.tag == "Boss_bullet"){
        current_healthP -= Boss_Gun_damage;
        playercolor.color = red;
        healthbar.sethealth(current_healthP);
      }
      if(tri.gameObject.tag == "Machine_bullet"){
        current_healthP -= machine_Gun_damage;
        playercolor.color = red;
        healthbar.sethealth(current_healthP);
      }
      
    }

    //For spawn Blood prefeb when Enemy is destroy//
    void Blood_enemy(){

      //for spwan blood prefeb when zombie is destroy//
      zombie = FindObjectsOfType<zombie>();
      for (int i = 0; i <zombie.Length; i++)
      {
         if(zombie[i].currenthealth <= 0){
         
            blood_splash.Play();
            Instantiate(blood,zombie[i].transform.position,zombie[i].transform.rotation);
         }
         
      } 
      // for AKM_player//
      akm_enemy = FindObjectsOfType<Akm_enemy>();
      for (int i = 0; i<akm_enemy.Length; i++)
      {
         if(akm_enemy[i].currenthealth_Aenmey <= 0){
         
            blood_splash.Play();
            Instantiate(blood,akm_enemy[i].transform.position,akm_enemy[i].transform.rotation);
         }
         
      }  
      //for GUN_player//
      Gun_enemy = FindObjectsOfType<gun_enemy>();
      for (int i = 0; i <Gun_enemy.Length; i++)
      {
         if(Gun_enemy[i].currenthealth_Genmey <= 0){
         
            blood_splash.Play();
            Instantiate(blood,Gun_enemy[i].transform.position,Gun_enemy[i].transform.rotation);
         }
         
      }

    }
    
    // For Audio of foot steps call in joystick events//
    public void footstep_(){
       footstep.Play();
    }
    public void footstep_1(){
       footstep.Stop();
    }
    
   


    
}
