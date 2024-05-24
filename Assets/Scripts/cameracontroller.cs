using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontroller : MonoBehaviour
{
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(Math.Clamp(player.transform.position.x,-15,15),Math.Clamp(player.transform.position.y,-7.5f,7.5f),transform.position.z);
        //transform.position = new Vector2(Mathf.Clamp(transform.position.x,-15,15),Mathf.Clamp(transform.position.y,-7.5f,7.5f));
         transform.position = new Vector3(player.transform.position.x,player.transform.position.y,transform.position.z);
    }
}
