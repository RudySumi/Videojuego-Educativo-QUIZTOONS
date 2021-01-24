﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformmove : MonoBehaviour
{
       
    public float speed= 1.5f;
    public float waitTime;
    public Transform[] moveSpots;
    public float startWaitTime=2;
    private int i=0;
    
    void Start()
    {
        waitTime = startWaitTime;
    }

    
    void Update()
    {
        
        transform.position=Vector2.MoveTowards(transform.position, moveSpots[i].transform.position,speed*Time.deltaTime);
        if(Vector2.Distance(transform.position,moveSpots[i].transform.position)<0.1f){
            if(waitTime<=0){
                if(moveSpots[i]!=moveSpots[moveSpots.Length-1]){
                    i++;
                }
                else{
                    i = 0;
                }
                waitTime=startWaitTime;

            }
            else{
                waitTime-=Time.deltaTime;
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision) {
		collision.collider.transform.SetParent(transform);
        
    }
    public void OnCollisionExit2D(Collision2D collision) {
		collision.collider.transform.SetParent(null);
        
    }
}
