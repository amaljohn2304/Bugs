using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_mov : MonoBehaviour
{   public Rigidbody2D rb;
    public CharacterController cntrl;
    public Animator anim;
    public SpriteRenderer sprite;
    public BoxCollider2D coll;
    public float pos_chck_pre;
    public float pos_chck_post;
    public int k=1000;
    [SerializeField] public AudioSource jumpSoundEffect;
    [SerializeField] public AudioSource swishSoundEffect;
    [SerializeField] public LayerMask jumpGround;


    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        cntrl=GetComponent<CharacterController>();
        anim=GetComponent<Animator>();
        sprite=GetComponent<SpriteRenderer>();
        coll=GetComponent<BoxCollider2D>();
       
        
    }

    // Update is called once per frame
    void Update() 
    {   
        k=k+1;
        pos_chck_pre=rb.transform.position.x;
        if (Input.GetKey("d")){
            rb.transform.Translate(transform.right*3*Time.deltaTime);
        }
        if (Input.GetKey("a")){
            rb.transform.Translate(transform.right*-3*Time.deltaTime);
        }
        if (Input.GetKey("w")&&rb.velocity.y<0.001){
            {
                if(isGround()){
                    jumpSoundEffect.Play();
                    rb.AddForce(transform.up*7,ForceMode2D.Impulse);

                }
            }
        }
        pos_chck_post=rb.transform.position.x;
        if (Input.GetKey("left shift")&&k>100){
                k=0;
                
            if(pos_chck_post>pos_chck_pre){
                anim.SetBool("swish",true);
                swishSoundEffect.Play();
                transform.position= new Vector2(pos_chck_post+3f,transform.position.y);
            }
            if(pos_chck_post<pos_chck_pre){
                anim.SetBool("swish",true);
                swishSoundEffect.Play();
                transform.position= new Vector2(pos_chck_post-3f,transform.position.y);
            }
        }
        else{
            anim.SetBool("swish",false);
        }
        

        
        if(pos_chck_post>pos_chck_pre && rb.velocity.y==0){
            anim.SetBool("run",true);
            
            sprite.flipX=false;
        }
        else if(pos_chck_post<pos_chck_pre && rb.velocity.y==0){
            anim.SetBool("run",true);
            sprite.flipX=true;
        }
        else{
            
            anim.SetBool("run",false);
        }
        if(pos_chck_post>pos_chck_pre){
            sprite.flipX=false;
        }
        if(pos_chck_post<pos_chck_pre){
            sprite.flipX=true;
        }
        if(rb.velocity.y!=0){
            anim.SetBool("in_air",true);
        }
        else{
            anim.SetBool("in_air",false);
        }
    }

    public bool isGround(){
        Debug.Log(Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpGround));
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpGround);

    }
        
}

   