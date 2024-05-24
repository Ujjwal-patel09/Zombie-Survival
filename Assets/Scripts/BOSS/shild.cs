using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shild : MonoBehaviour
{
    public GameObject[] transformers;

    // Update is called once per frame
    void Update()
    {
        transformers = GameObject.FindGameObjectsWithTag("transformer");
        if(transformers.Length == 0){
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "bullet"){
            Destroy(other.gameObject);
        }
    }
}
