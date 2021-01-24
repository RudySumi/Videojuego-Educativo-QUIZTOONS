using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class icons : MonoBehaviour
{
   public AudioSource clip;
   
   private void OnTriggerEnter2D(Collider2D collision){
       if(collision.CompareTag("player")){
           GetComponent<SpriteRenderer>().enabled=false;
           //gameObject.transform.GetChild(0).gameObject.SetActive(true);
           Destroy(gameObject,0.5f);
           int score = PlayerPrefs.GetInt("score") + 5;
           PlayerPrefs.SetInt("score", score);
           clip.Play();

       }
   }
}
