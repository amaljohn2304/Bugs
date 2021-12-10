using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class item_collector : MonoBehaviour
{
    public int blue_drop_count=0;
    public int mud_drop_count=0;
    public Rigidbody2D rb;
    public Animator anim;
    [SerializeField] public Text bl_drop_cnt;
    [SerializeField] public AudioSource blueSoundEffect;
    [SerializeField] public AudioSource mudSoundEffect;
    [SerializeField] public AudioSource deathhSoundEffect;
    [SerializeField] public AudioSource levelSoundEffect;

    public  void OnTriggerEnter2D(Collider2D collision){
        anim=GetComponent<Animator>();
        rb= GetComponent<Rigidbody2D>();
        if(collision.gameObject.CompareTag("blue_drop")){
            anim.SetBool("burst",true);
            Destroy(collision.gameObject);
            blue_drop_count++;
            bl_drop_cnt.text="Blues : "+blue_drop_count; 
            blueSoundEffect.Play();

        }
        if(collision.gameObject.CompareTag("mud_drop")){
            anim.SetBool("burst",true);
            Destroy(collision.gameObject);
            mud_drop_count++;
            bl_drop_cnt.text="Blues : "+blue_drop_count; 
            mudSoundEffect.Play();

        }
        if(collision.gameObject.CompareTag("toxic")){
            anim.SetTrigger("choke");
            rb.bodyType=RigidbodyType2D.Static; 
            deathhSoundEffect.Play();
            levelSoundEffect.Stop();
            
        }
    }

    public void restartlevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
