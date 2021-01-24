using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class answer : MonoBehaviour
{
    public GameObject feed_correct, feed_wrong;
    void Start()
    {
         
    }
    
    public void answers(bool answer){
        if(answer){
            
            feed_correct.SetActive(false);
            feed_correct.SetActive(true);
            
            //feed_correct.GetComponent<Image>().enabled=true;
            //feed_correct.GetComponent<Image>().enabled=false;


            int score = PlayerPrefs.GetInt("score") + 10;
            PlayerPrefs.SetInt("score", score);
        }
        else{
            feed_wrong.SetActive(false);
            feed_wrong.SetActive(true);
            
        }
        gameObject.SetActive(false);
        transform.parent.GetChild(gameObject.transform.GetSiblingIndex()+1).gameObject.SetActive(true);
    }

    void Update()
    {
        
    }
}
