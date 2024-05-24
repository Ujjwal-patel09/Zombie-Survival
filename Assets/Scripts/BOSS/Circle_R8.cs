using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle_R8 : MonoBehaviour
{
    
  public GameObject[] enemy;
  public Transform spawn_point;
  public bool isspawn = false;
  public Animator anim;
  public GameObject medic;
  public AudioSource blast;

  public Canvas canvas;
  public health health;
  public int maxhealth_C = 50;
  public int currentHealth_C;
  public int damage_C = 1;
  

  private void Start() {

     currentHealth_C = maxhealth_C;
     health.maxhealth(maxhealth_C);
     canvas.enabled = false;
     anim = GetComponent<Animator>();

  }

  private void Update() {

    if(currentHealth_C <= 0){
        isspawn = false;
        anim.SetTrigger("isBlast");
        StartCoroutine(is_Destroy());
        return;
    }
    
    if(isspawn == true){
        
        StartCoroutine(is_Enemy_spawn());
    }
  }

  IEnumerator is_Enemy_spawn(){// For enemy spawn //
    isspawn = false;
    yield return new WaitForSeconds(1);
    Instantiate( enemy[Random.Range( 0,enemy.Length)],spawn_point.transform.position,spawn_point.transform.rotation);
    yield return new WaitForSeconds(15);
    isspawn= true; 
  }

  IEnumerator is_Destroy(){
    yield return new WaitForSeconds(2);
    Destroy(this.gameObject);
  }

  private void OnTriggerEnter2D(Collider2D other) {
     
    if(other.gameObject.tag == "bullet"){
        
        Destroy(other.gameObject);
        canvas.enabled = true;
        currentHealth_C -= damage_C;
        health.sethealth1(currentHealth_C);

    }
  }

  private void OnDestroy() {

    Instantiate(medic,transform.position,transform.rotation);

  }
  
  // this function is called in animation functions//
  public void blast_sound(){
    blast.Play();
  }
  

}
