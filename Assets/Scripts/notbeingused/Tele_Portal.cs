﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tele_Portal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Touch()
    {
        SceneManager.LoadScene(1);
      //  Debug.Log("touch");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

      
       if (collision.tag == "Player")
       {

            Debug.Log("nizzle");
            SceneManager.LoadScene(1);
       }
    }











}
