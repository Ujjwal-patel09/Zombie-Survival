using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ckeck_point : MonoBehaviour
{
   private Game_reloader GR;

   private void Start() {
      GR = FindObjectOfType<Game_reloader>();
      

   }

   private void OnTriggerEnter2D(Collider2D other) {
     if(other.gameObject.tag == "Player"){
        
        GR.lastcheck_point = transform.position;
     }
   }
}
