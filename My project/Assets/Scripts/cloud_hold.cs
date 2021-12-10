using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloud_hold : MonoBehaviour
{
    // Start is called before the first frame update
   public void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.name=="hero_model"){
            collision.gameObject.transform.SetParent(transform);
        }
   }
   public void OnCollisionExit2D(Collision2D collision){

    if(collision.gameObject.name=="hero_model"){
            collision.gameObject.transform.SetParent(null);
        }

   }
}
