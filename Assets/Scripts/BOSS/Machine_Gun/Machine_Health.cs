using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine_Health : MonoBehaviour
{ 
    public health health_machine;
    public int max_machine_health;
    int current_machine_health;
    public int Damage;
    public Canvas canvas;
   

    void Start()
    {
        current_machine_health = max_machine_health;
        health_machine.maxhealth(max_machine_health);
    }

    // Update is called once per frame
    void Update()
    {
        if(current_machine_health <= 0){
            Destroy(this.gameObject);
        }
    }

   
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "bullet"){
            Destroy(other.gameObject);
            canvas.enabled = true;
            current_machine_health -= Damage;
            health_machine.sethealth1(current_machine_health);
        }
    }

}
