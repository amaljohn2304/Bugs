using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burst_bubble : MonoBehaviour
{   public Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        
        anim=GetComponent<Animator>();
    }

    public  void OnTriggerEnter2D(Collider2D collision){
        anim=GetComponent<Animator>();
                
        if(collision.gameObject.CompareTag("player")){
            anim.SetBool("burst",true);
            
        }
        
    }
}
