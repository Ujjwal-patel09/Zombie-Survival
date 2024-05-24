using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using Pathfinding;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;

public class Zombie_Field : MonoBehaviour
{
  
     public Transform[] zombie_swpanpoints;
     public Transform[] gun_spwanpoints;
     public Transform[] AKM_spawnpoints;
     public GameObject zombie;
     public GameObject gun_enemy;
     public GameObject AKM_enemy;

     
    
    private void Start() {
      
     /* zombie_swpanpoints = null;
      gun_spwanpoints = null;
      zombie = null;
      gun_enemy = null;*/
    }

    private void OnTriggerEnter2D(Collider2D col) {

        if(col.gameObject.tag == "Player"){

           for (int i = 0; i <zombie_swpanpoints.Length ; i++)
           {
              Instantiate(zombie,zombie_swpanpoints[i].transform.position,quaternion.identity);
             
           } 

            for (int i = 0; i <gun_spwanpoints.Length ; i++)
           {
              Instantiate(gun_enemy,gun_spwanpoints[i].transform.position,quaternion.identity);
             
           } 

            for (int i = 0; i <AKM_spawnpoints.Length ; i++)
           {
              Instantiate(AKM_enemy,AKM_spawnpoints[i].transform.position,quaternion.identity);
             
           } 
        
        }
        
    }
  
}
