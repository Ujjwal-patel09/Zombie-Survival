using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;


//using System.Drawing;
using UnityEngine;

public class door1 : MonoBehaviour
{
   
    public Animator anim;
    public player player;

    //this is to identify the door with color
    public GameObject door;
    SpriteRenderer doorcolor;

    // For identify is any zombie is alive and if any enemy is alive doors are lock//
    public GameObject[] Enemy;
    public bool isbattle = false;
  

    // list of colors//   
    Color red    = new Color(1,0,0),
          yellow = new Color(0.85f,0.75f,0.4f),
          green  = new Color(0.35f,0.7f,0.4f),
          grey   = new Color(0.3f,0.25f,0.2f),
          Blue   = new Color(0.25f,0.6f,0.85f);


    private void Start() {
    
        doorcolor = door.GetComponent<SpriteRenderer>();
        anim = door.GetComponent<Animator>();
        
    }

    private void Update() {
      
      //for detecting is any enemy is aliave or not//
      Enemy = GameObject.FindGameObjectsWithTag("Enemy");
      if(Enemy.Length != 0){
        isbattle = true;
      }

      if( Enemy.Length == 0 ){
        isbattle = false;
      }
        
    }
   
    
 
 
    private void OnTriggerEnter2D(Collider2D col) {
        //normal door//
        if(col.gameObject.tag == "Player"  && doorcolor.color == Color.white && isbattle == false){
            
            anim.enabled = true;
            anim.Play("dooropen");

        }
        //red door//
        if(col.gameObject.tag == "Player" && player.iskeyred == true && doorcolor.color == red && isbattle == false){

            anim.enabled = true;
            anim.Play("dooropen");
        }
        //green door//
         if(col.gameObject.tag == "Player" && player.iskeygreen == true && doorcolor.color == green && isbattle == false){

            anim.enabled = true;
            anim.Play("dooropen");
        }
        //yellow door//
         if(col.gameObject.tag == "Player" && player.iskeyyellow == true && doorcolor.color == yellow && isbattle == false){

            anim.enabled = true;
            anim.Play("dooropen");
        }
        //grey door//
          if(col.gameObject.tag == "Player" && player.iskeygrey == true && doorcolor.color == grey && isbattle == false){

            anim.enabled = true;
            anim.Play("dooropen");
        }
        //Blue door//
          if(col.gameObject.tag == "Player" && player.iskeyBlue == true && doorcolor.color == Blue && isbattle == false){

            anim.enabled = true;
            anim.Play("dooropen");
        }


    }


    private void OnTriggerExit2D(Collider2D col) {
        
        if(col.gameObject.tag == "Player"){
            
            anim.Play("doorclose");
        }
       
        
    }
}
