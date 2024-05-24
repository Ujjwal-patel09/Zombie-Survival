using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class gun_enemy : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer Gun_enemy;
    Color red =  Color.red;
    public player _Player;
    public float minimumdistance;
    public AIPath aIPath;
    public Animator anim;

    // for shooting//
    public GameObject bullet;
    public GameObject[] enemy_flash_destroy;
    public GameObject enemy_flash;
    public GameObject bulletspawner;
    public float firerate;
    private float nextfire;
    private bool isinstantiate = false;
    public AudioSource gun_sound;

    //for Reloading//
    public int maxbullet = 10;
    public int currentbullet;
    private float reloadtime = 1f;
    private bool isreloading = false;

    //For health//
     public int maxhealth_Genemy = 20;
    public int damage_Genemy = 2;
    public int currenthealth_Genmey;
    public Canvas canvas;
    public health health;

   

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        Gun_enemy = GetComponent<SpriteRenderer>();
        _Player = FindObjectOfType<player>();
        aIPath = GetComponent<AIPath>();
        currentbullet = maxbullet;
        anim = GetComponent<Animator>();

        //For  health//
        currenthealth_Genmey = maxhealth_Genemy;
        health.maxhealth(maxhealth_Genemy);
        canvas.enabled = false;
    }

   private void Update() {
     
      if(_Player.current_healthP <=0){
        
        isinstantiate = false;
        anim.SetBool("isshoot",false);
        return;
      }

       player_follow();

      //for gun_enemy died when health is 0//
        if(currenthealth_Genmey<=0){
          
          _Player.playercolor.color = Color.white;
          Destroy(this.gameObject);
          
        }

        // destroy enemy_flash//
        enemy_flash_destroy = GameObject.FindGameObjectsWithTag("Enemy_flash");
        for (int i = 0; i < enemy_flash_destroy.Length; i++)
        {
          Destroy(enemy_flash_destroy[i],0.1f); 
        }


    
    

   }

   void player_follow(){
    
       float playertoenemydis =  Vector2.Distance(transform.position,_Player.transform.position);

      if(playertoenemydis > minimumdistance){

        aIPath.enabled = true;
        anim.SetBool("ismove",true);
        anim.SetBool("isshoot",false); 
        _Player.playercolor.color = Color.white;

       
       }else{

         aIPath.enabled = false;
         anim.SetBool("ismove",false);
         anim.SetBool("isshoot",true);
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
         
       }

     Vector3 look = transform.InverseTransformPoint(_Player.transform.position);
     float zangle = Mathf.Atan2(look.y,look.x)*Mathf.Rad2Deg;
     transform.Rotate(0,0,zangle+7);
    
   }

   void shoot(){

      if(isinstantiate == true  ){

        Instantiate(bullet,bulletspawner.transform.position,bulletspawner.transform.rotation);//bullet spwan//
        gun_sound.Play();
        Instantiate(enemy_flash,bulletspawner.transform.position,bulletspawner.transform.rotation);//flash spwan//
        //Destroy(GameObject.FindGameObjectWithTag("Enemy_flash"),0.1f);//DESTROY IS IN LINE 70//
        
        

      }
   }
    IEnumerator Reload(){

      isreloading = true;
      anim.SetBool("isreload",true);

      yield return new WaitForSeconds(reloadtime);

      currentbullet = maxbullet;
      isreloading = false;
      anim.SetBool("isreload",false);
      

    }

     private void OnTriggerEnter2D(Collider2D col) {
      //for Gun_enemy health//
      if(col.gameObject.tag == "bullet"){
        
        Destroy(col.gameObject);
        Gun_enemy.color = red;
        currenthealth_Genmey -= damage_Genemy;
        canvas.enabled = true;
        health.sethealth1(currenthealth_Genmey);

      }
      
    }

   
}
