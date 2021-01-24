using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tresuare : MonoBehaviour
{
    public GameObject optionPanel;

    private void OnTriggerEnter2D(Collider2D collision){
       if(collision.CompareTag("player")){
           GetComponent<SpriteRenderer>().enabled=false;
           //gameObject.transform.GetChild(0).gameObject.SetActive(true);
           Destroy(gameObject,0.5f);
           Time.timeScale = 0;
           optionPanel.SetActive(true);
       }
   }
}
