using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transformer : MonoBehaviour
{
    public health health_trans;
    public int max_trans_health = 30;
    public int current_trans_health;
    public int damage = 1;
    public Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        current_trans_health = max_trans_health;
        health_trans.maxhealth(max_trans_health);
    }

    // Update is called once per frame
    void Update()
    {
        if(current_trans_health <= 0){
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "bullet"){
            Destroy(other.gameObject);
            canvas.enabled = true;
            current_trans_health -= damage;
            health_trans.sethealth1(current_trans_health);
        }
    }
}
