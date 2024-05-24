using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public float bulletspeed;
    public GameObject particles;

    void Start()
    {
       
        rb = GetComponent<Rigidbody2D>();
        

    }

    private void FixedUpdate() {
        
        rb.velocity = transform.right!*bulletspeed*Time.fixedDeltaTime;
    }

   

    private void OnTriggerEnter2D(Collider2D colbullet) {
        
         if(colbullet.gameObject.tag == "Wall" || colbullet.gameObject.tag == "Box" || colbullet.gameObject.tag == "Door"
          || colbullet.gameObject.tag == "Player" || colbullet.gameObject.tag == "Gun_enemy" || colbullet.gameObject.tag =="Enmey"){
            
            Instantiate(particles,transform.position,quaternion.identity);
             Destroy(this.gameObject);
        }
    }
   
}
