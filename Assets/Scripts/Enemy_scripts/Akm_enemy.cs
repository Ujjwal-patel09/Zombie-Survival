using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class Akm_enemy : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer AKM_enemy;
    Color red = Color.red;
    public player _Player;
    public float minimumdistance;
    public AIPath aIPath;
    public Animator anim;

    // for shooting//
    public GameObject bullet;
    public GameObject AKM_flash;
    public GameObject[] flash;
    public GameObject bulletspawner;
    public float firerate;
    private float nextfire;
    private bool isinstantiate = false;
    public AudioSource akm_sound;

    //for Reloading//
    public int maxbullet = 30;
    public int currentbullet;
    private float reloadtime = 1f;
    private bool isreloading = false;

    //For health//
     public int maxhealth_Aenemy = 30;
    public int damage_Aenemy = 2;
    public int currenthealth_Aenmey;
    public Canvas canvas;
    public health health;

   

    private void Start() {

        rb = GetComponent<Rigidbody2D>();
        AKM_enemy = GetComponent<SpriteRenderer>();
        _Player = FindObjectOfType<player>();
        aIPath = GetComponent<AIPath>();
        currentbullet = maxbullet;
        anim = GetComponent<Animator>();

        //For  health//
        currenthealth_Aenmey = maxhealth_Aenemy;
        health.maxhealth(maxhealth_Aenemy);
        canvas.enabled = false;
    }

   private void Update() {

     
      //for akm_enemy still idel when player is die //
        if(_Player.current_healthP <= 0){
          
          isinstantiate = false;
          anim.SetBool("isAKM_shoot",false);
          return;
        }   


        player_follow();


      //for gun_enemy died when health is 0//
        if(currenthealth_Aenmey<=0){
          
          _Player.playercolor.color = Color.white;
          Destroy(this.gameObject);
          
        }

    flash = GameObject.FindGameObjectsWithTag("AKM_flash");
    for (int i = 0; i <flash.Length; i++)
    {
       Destroy(flash[i],0.1f);
    }

   }

   void player_follow(){
    
       float playertoenemydis =  Vector2.Distance(transform.position,_Player.transform.position);

      if(playertoenemydis < minimumdistance){


         aIPath.enabled = false;
         anim.SetBool("isAKM_shoot",true);
          if(isreloading)
          return;

          if(currentbullet <= 0){

          StartCoroutine (Reload());
          return;
          }
       
          if(Time.time > nextfire){

          
              isinstantiate = true;
              nextfire = (Time.time + firerate);
              currentbullet--;
              shoot();
           

          }
       
       }else{

        aIPath.enabled = true;
        anim.SetBool("isAKM_shoot",false);
        _Player.playercolor.color = Color.white;
         
       }

     Vector3 look = transform.InverseTransformPoint(_Player.transform.position);
     float zangle = Mathf.Atan2(look.y,look.x)*Mathf.Rad2Deg;
     transform.Rotate(0,0,zangle+7);
    
   }

   void shoot(){

      if(isinstantiate == true  ){

        Instantiate(bullet,bulletspawner.transform.position,bulletspawner.transform.rotation);//bullet spwan//
        akm_sound.Play();
        Instantiate(AKM_flash,bulletspawner.transform.position,bulletspawner.transform.rotation);//flash spwan//
       // DestroyImmediate(GameObject.FindGameObjectWithTag("AKM_flash"));
        

      }
   }
    IEnumerator Reload(){

      isreloading = true;
      anim.SetBool("isAKM_reload",true);

      yield return new WaitForSeconds(reloadtime);

      currentbullet = maxbullet;
      isreloading = false;
      anim.SetBool("isAKM_reload",false);
      

    }

     private void OnTriggerEnter2D(Collider2D col) {
      //for Gun_enemy health//
      if(col.gameObject.tag == "bullet"){
        
        Destroy(col.gameObject);
        AKM_enemy.color = red;
        currenthealth_Aenmey -= damage_Aenemy;
        canvas.enabled = true;
        health.sethealth1(currenthealth_Aenmey);

      }
      
    }

   
}


