using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Room7_Enemy : MonoBehaviour
{
    public Circle[] circle;


    private void Start() {

        circle = FindObjectsOfType<Circle>();

    }

    private void Update() {
        
        for (int i = 0; i < circle.Length; i++)
        {
            if(circle[i].IsDestroyed() == true){
                
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.gameObject.tag == "Player"){
           
           for (int i = 0; i <circle.Length; i++)
           {
            circle[i].isspawn = true;
           }
        }
    }



  
}
