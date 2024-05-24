using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room8_EnemyField : MonoBehaviour
{
     public Circle_R8[] circle;
     public GameObject Boss;


    private void Start() {


    }
    private void Update() {
        circle = FindObjectsOfType<Circle_R8>();
        if(circle.Length == 0){
            Debug.Log("a");
            Boss.SetActive(true);
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
