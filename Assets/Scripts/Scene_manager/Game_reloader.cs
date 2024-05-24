using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_reloader : MonoBehaviour
{
   private static Game_reloader instance;
   public Vector2 lastcheck_point;
   private void Awake() {
     if(instance == null){
        instance = this;
        DontDestroyOnLoad(instance);
     }else{

        Destroy(gameObject);
     }
   }
}
