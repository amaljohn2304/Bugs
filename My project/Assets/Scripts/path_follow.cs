using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class path_follow : MonoBehaviour
{
    [SerializeField] public GameObject[] waypoints;
    public int current_in=0;

    [SerializeField] public float speed=2f;

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(waypoints[current_in].transform.position,transform.position)<0.1f){
            current_in++;
            if(current_in>=waypoints.Length){
                current_in=0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position,waypoints[current_in].transform.position,Time.deltaTime*speed);
    }
}
