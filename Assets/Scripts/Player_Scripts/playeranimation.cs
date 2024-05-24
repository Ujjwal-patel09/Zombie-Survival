using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playeranimation : MonoBehaviour
{
    public Animator anim;
    [SerializeField]FixedJoystick joystick;
    [SerializeField]FixedJoystick joystick1;

    public shooting shooting;
    public player player;

   // public bool isakm = false;//For checking akm is collected or not//


   
    void Start()
    {
        anim = GetComponent<Animator>();
        player = FindAnyObjectByType<player>();
    }

    void Update()
    {
        if(joystick.Horizontal>=.1f || joystick.Horizontal<=-.1f || joystick.Vertical>=.1f || joystick.Vertical<=-.1f){

            anim.SetBool("ismove",true);
        }else{

            anim.SetBool("ismove",false);
        }

        //normal gunplayer shoot animation//
        if(joystick1.Horizontal>=.7f || joystick1.Horizontal<=-.7f || joystick1.Vertical>=.7f || joystick1.Vertical<=-.7f){

            anim.SetBool("isshoot",true);
        }else{

            anim.SetBool("isshoot",false);
        }

        //AKM gunplayer idel animation//
        if(player.isakm == true){

               anim.SetBool("isAKM",true);

        }

        //AKM gunplayer shoot animation//
        if((joystick1.Horizontal>=.7f && player.isakm == true) || (joystick1.Horizontal<=-.7f && player.isakm == true)
           || (joystick1.Vertical>=.7f && player.isakm == true) || (joystick1.Vertical<=-.7f && player.isakm ==true)){

            anim.SetBool("isAKMshoot",true);
        }else{

            anim.SetBool("isAKMshoot",false);
        }

        //reload normal gun//
        if(shooting.currentbullet<=0){

            anim.SetBool("isreload",true);
        }else{

            anim.SetBool("isreload",false);
        }

        //AKM reload animation//
        if(shooting.currentbullet<=0 && player.isakm == true){

            anim.SetBool("isAKMreload",true);
        }else{

            anim.SetBool("isAKMreload",false);
        }
        // destroying prefebs which spwan from other game objects //
        Destroy(GameObject.FindGameObjectWithTag("blood"),1.5f);
        Destroy(GameObject.FindGameObjectWithTag("particles"));
    }

   
   
        
    
}
