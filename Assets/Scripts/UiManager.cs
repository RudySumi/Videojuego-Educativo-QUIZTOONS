using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UiManager : MonoBehaviour
{
    public GameObject settingPanel;

    public void OptionPanel(){
        Time.timeScale = 0;
        settingPanel.SetActive(true);

    }

    public void Return(){
        Time.timeScale = 1;
        settingPanel.SetActive(false);
    }

    public void GoMainMenu(){
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
    
    public void QuitGame(){
        Application.Quit();
    }

    public void level_1(){
        Time.timeScale = 1;
        SceneManager.LoadScene("Scene01");
        
    }

    public void level_2(){
        Time.timeScale = 1;
        SceneManager.LoadScene("Scene02");
    }

    public void level_3(){
        Time.timeScale = 1;
        SceneManager.LoadScene("Scene03");
    }

    
}
