using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Pathfinding;
using System.Reflection.Emit;
using Unity.Mathematics;
using System.Runtime.Serialization;

public class zombie : MonoBehaviour
{
    // public scripts//
    public player player;
    public AIPath path;
    SpriteRenderer Zombie;
    Color red1 = Color.red;
   
   // zombie behaviour variables//
    public bool isplayercome = false;
    public Animator zomanim;
    [SerializeField] float movespeed;
    [SerializeField] Transform[] patrolpoints;
    [SerializeField] float minimumdistance;
   
    // zombie health variables//
    public int maxhealth = 10;
    public int damage = 2;
    public int currenthealth;
    public Canvas canvas;
    public health health;
    
  
   
    //player health varibles//
    public SpriteRenderer playercolor;
    Color red = new Color(1,0.4f,0.4f);
    public healthbar healthbar;

    private void Start() {

        Zombie = GetComponent<SpriteRenderer>();
        zomanim = GetComponent<Animator>();
        path = GetComponent<AIPath>();
        
        //Find player//
         player = FindObjectOfType<player>();
       

        //zombie health//
        currenthealth = maxhealth;
        health.maxhealth(maxhealth);
        canvas.enabled = false;
       
    }

    
    void Update()
    {
        

        // Zombie follow player//
           playerfollow();

      
        // for stay idel when the player is die//
        if(player.current_healthP == 0){
          zomanim.SetBool("isidel",true);
        }

        //for zombie died when health is 0//
        if(currenthealth<=0){
          
           player.playercolor.color = Color.white;
          Destroy(this.gameObject);
          
        }
        
       

    }
   

    void playerfollow(){//for zombie follow player//

       float playertoenemydis =  Vector2.Distance(transform.position,player.transform.position);

      if(playertoenemydis > minimumdistance){

        path.enabled = true;
        zomanim.SetBool("isattack",false);
        player.playercolor.color = Color.white;

      }else{
        path.enabled = false;
        zomanim.SetBool("isattack",true); 
        
      }
       // for looking towards player//
       Vector3 look = transform.InverseTransformPoint(player.transform.position);
       float zangle = Mathf.Atan2(look.y,look.x)*Mathf.Rad2Deg;
       transform.Rotate(0,0,zangle);

    }
    
   
    // This function is used in animation function of zombieattack anim for player health//
    public void player_health(){

      player.player_health();
      
    }

    private void OnTriggerEnter2D(Collider2D col) {
      //for zombie health//
      if(col.gameObject.tag == "bullet"){
        
        Destroy(col.gameObject);
        Zombie.color = red1;
        currenthealth -= damage;
        canvas.enabled = true;
        health.sethealth1(currenthealth);

      }
      
    }

   
  

   
}
