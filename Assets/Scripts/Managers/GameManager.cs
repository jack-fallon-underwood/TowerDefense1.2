using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameManager : Singleton<GameManager>
{

    private bool gameOver = false;

    [SerializeField] private GameObject gameOverMenu;

    [SerializeField] private GameObject inGameMenu;

    [SerializeField] private GameObject optionsMenu;

    [SerializeField] private GameObject keybindManager;

    private List<Monster> activeMonsters = new List<Monster>();

    //public ObjectPool Pool {get;set; }


    // Update is called once per frame
    void Update()
    {

              HandleEscape();
        
        //Executes click target
        //ClickTarget();
    }

     void HandleEscape()
    {   
       
       if (Input.GetKey(KeyCode.Escape)) //Moves right
          {
            ShowIngameMenu();   
          }              
    }

    public void GameOver()
    {
        if(!gameOver)
        {
            gameOver = true;
            gameOverMenu.SetActive(true);
        }
    }

     void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

     void QuitGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

     void ShowIngameMenu()
    {
        if(optionsMenu.activeSelf)
        {
            ShowMain();
        }

        else
        {
        
            inGameMenu.SetActive(!inGameMenu.activeSelf);

            if(!inGameMenu.activeSelf)
            {
                Time.timeScale = 1;
            }
            else{
                Time.timeScale = 0;
            }
        }
        
    }

   

     void ShowOptions()
    {
        inGameMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

     void ShowMain()
    {
        inGameMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }
}

   












