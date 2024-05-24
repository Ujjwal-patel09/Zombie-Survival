using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class shooting : MonoBehaviour
{
   
    public GameObject flash;
    public FixedJoystick joystick1;
    public GameObject bullet;
    public GameObject bulletspawner;
    public float firerate;
    public AudioSource Gun_shot;
    public AudioSource AKM_shot;
    public AudioSource Gun_reload;
    public AudioSource AKM_reload;
    public player player;

    private float nextfire;
    private Vector2 move;
    private bool isinstantiate = false;

    //for Reloading//
    public int maxbullet = 10;
    public int currentbullet;
    private float reloadtime = 1f;
    private bool isreloading = false;

    private void Start() {

      currentbullet = maxbullet; 
     // joystick1 = FindObjectOfType<FixedJoystick>(); 

    }

    private void Update() {

        if(isreloading)
          return;

        if(currentbullet <= 0){

          StartCoroutine (Reload());
          return;
        }
       
        if((joystick1.Horizontal >=.7f || joystick1.Horizontal<=-.7f 
            ||joystick1.Vertical>=.7f || joystick1.Vertical<=-.7 ) && Time.time > nextfire){

          
          isinstantiate = true;
          nextfire = Time.time + firerate;
          currentbullet--;
          shoot();
           

        }
        else if(joystick1.Horizontal == 0 || joystick1.Vertical == 0){

          isinstantiate = false;
        }

    }
    
    void shoot(){

      if(isinstantiate == true  ){

        Instantiate(bullet,bulletspawner.transform.position,bulletspawner.transform.rotation);//bullet spwan//
        if(player.isakm == true){
          AKM_shot.Play();
        }else{
          Gun_shot.Play();
        }
        Instantiate(flash,bulletspawner.transform.position,bulletspawner.transform.rotation);//flash spwan//
        Destroy(GameObject.FindWithTag("flash"),0.1f);//flash destroy//

      }
    }

    IEnumerator Reload(){

      isreloading = true;
      Debug.Log("reloading");
      if(player.isakm == true){
        AKM_reload.Play();
        reloadtime = 2f;
      }else{
        Gun_reload.Play();
      }

      yield return new WaitForSeconds(reloadtime);

      currentbullet = maxbullet;
      isreloading = false;
      

    }

    

}
